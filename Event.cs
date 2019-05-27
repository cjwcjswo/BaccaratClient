using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
using System.Windows.Forms;
using Protocol;

namespace BaccaratClient
{
    
    public class PacketEvent
    {
        private static BcApp _app;
        private static Thread _roomThread;
        private static RoomForm _appRoomForm;
        public delegate void PacketEventProcess(short result, byte[] bodyData);

        public PacketEvent(BcApp app)
        {
            _app = app;
        }

        public void LoginEvent(short result, byte[] bodyData)
        {
            if (result != Error.ERROR_CODE_NONE)
            {
                MessageBox.Show(Error.ErrorDic[result]);
                return;
            }
            User.MyInfo.Nickname = User.MyInfo.TempNickname;
            User.MyInfo.UniqueId = LoginResponse.Parser.ParseFrom(bodyData).SessionUniqueId;
            _app.Invoke(new MethodInvoker(
                delegate { _app.EventLoginUiSuccess(); }));
        }

        public void RoomEnterEvent(short result, byte[] bodyData)
        {
            if (result != Error.ERROR_CODE_NONE)
            {
                MessageBox.Show(Error.ErrorDic[result]);
                return;
            }
            
            var response = RoomEnterResponse.Parser.ParseFrom(bodyData);
            User.MyInfo.CurrentRoom = response.RoomNum;
            User.NewCurrentRoomUserList(new List<User>());
            var roomForm = new RoomForm(_app, _app.Client);
            _appRoomForm = roomForm;
            
            _roomThread = new Thread(delegate()
            {
                roomForm.SetRoomNumText(response.RoomNum);
                Application.Run(_appRoomForm);
            });
            _roomThread.Start();
            var newUser = new User(User.MyInfo.Nickname + "(나)", User.MyInfo.UniqueId);
            User.CurrentRoomUserList.Add(newUser);
            _appRoomForm.AddUserToUserListBox(newUser);
        }

        public void RoomNewUserInfoEvent(short result, byte[] bodyData)
        {
            if (result != Error.ERROR_CODE_NONE)
            {
                MessageBox.Show(Error.ErrorDic[result]);
                return;
            }

            var packet = RoomNewUserInfoBroadcast.Parser.ParseFrom(bodyData);
            var newUser = new User(packet.UserInfo.Nickname, packet.UserInfo.SessionUniqueId);
            User.CurrentRoomUserList.Add(newUser);
            _appRoomForm.AddUserToUserListBox(newUser);
        }

        public void RoomUserInfoListEvent(short result, byte[] bodyData)
        {
            if (result != Error.ERROR_CODE_NONE)
            {
                MessageBox.Show(Error.ErrorDic[result]);
                return;
            }
            
            var packet = RoomUserListNotify.Parser.ParseFrom(bodyData);

            foreach (var user in packet.UserInfo)
            {
                var userObj = new User(user.Nickname, user.SessionUniqueId);
                User.CurrentRoomUserList.Add(userObj);
                _appRoomForm.AddUserToUserListBox(userObj);
            }
        }

        public void RoomChatResponseEvent(short result, byte[] bodyData)
        {
            if (result != Error.ERROR_CODE_NONE)
            {
                MessageBox.Show(Error.ErrorDic[result]);
            }
        }

        public void RoomChatBroadcastEvent(short result, byte[] bodyData)
        {
            var packet = RoomChatBroadcast.Parser.ParseFrom(bodyData);
            _appRoomForm.AddChatMessage(ParseChatMessage(packet.Nickname, packet.Message));
        }

        public void RoomLeaveBroadcastEvent(short result, byte[] bodyData)
        {
            var packet = RoomLeaveBroadcast.Parser.ParseFrom(bodyData);
            _appRoomForm.RemoveUserToUserListBox(packet.SessionUniqueId);
        }

        public void GameResponseEvent(short result, byte[] bodyData)
        {
            if (result != Error.ERROR_CODE_NONE)
            {
                MessageBox.Show(Error.ErrorDic[result]);
            }
        }

        public void GameBettingStartBroadcastEvent(short result, byte[] bodyData)
        {
            _appRoomForm.ClearImage();
        }
        public void GameBettingBroadcastEvent(short result, byte[] bodyData)
        {
            if (result != Error.ERROR_CODE_NONE)
            {
                MessageBox.Show("베팅 브로드캐스팅 오류로 UI를 초기화합니다.");
                _appRoomForm.GameStartUiChange(true, true);
                return;
            }

            var broadcast = BettingBroadcast.Parser.ParseFrom(bodyData);

            var nickname = "";
            foreach (var user in User.CurrentRoomUserList)
            {
                if (user.UniqueId != broadcast.SessionUniqueId) continue;
                nickname += user.Nickname;
                break;
            }
            
            var bettingType = "(";
            switch (broadcast.BettingType)
            {
                case Baccarat.BACCARAT_TYPE_PLAYER:
                {
                    bettingType += "플레이어)";
                    break;
                }

                case Baccarat.BACCARAT_TYPE_BANKER:
                {
                    bettingType += "뱅커)";
                    break;
                }

                case Baccarat.BACCARAT_TYPE_DRAW:
                {
                    bettingType += "무승부)";
                    break;
                }

                default:
                {
                    MessageBox.Show("올바르지 않은 타입입니다");
                    break;
                }
            }
            _appRoomForm.AddUserToBettingList(nickname + bettingType);
            
        }

        public void GameRoundEvent(short result, byte[] bodyData)
        {
            var broadcast = BaccaratRoundBroadcast.Parser.ParseFrom(bodyData);
            _appRoomForm.SetUserCardImage(broadcast.BaccaratType, broadcast.Round, broadcast.CardType, broadcast.CardNum);
            _appRoomForm.AddTextToLogBox(GetGameStatusLog(broadcast.BaccaratType, broadcast.Round, broadcast.CardType, broadcast.CardNum));
        }

        public void GameResultEvent(short result, byte[] bodyData)
        {
            var broadcast = BaccaratResultBroadcast.Parser.ParseFrom(bodyData);
            var resultText = "";
            if (broadcast.PlayerSum == broadcast.BankerSum)
            {
                resultText += "무승부!!";
            } 
            else if (broadcast.PlayerSum > broadcast.BankerSum)
            {
                resultText += "플레이어 승리!";
            }
            else
            {
                resultText += "뱅커 승리!";
            }
            
            _appRoomForm.AddTextToLogBox(resultText);
            _appRoomForm.GameStartUiChange(true, true);
        }
        
        private static string ParseChatMessage(string nickname, string message)
        {
            return "[" + nickname + "]: " + message;
        }

        private static string GetGameStatusLog(uint userType, uint round, uint cardType, uint cardNum)
        {
            var result = "";
            if (userType == Baccarat.BACCARAT_TYPE_PLAYER)
            {
                result += "[P] ";
            }
            else
            {
                result += "[B] ";
            }

            result += round + "R-> ";
            result += Baccarat.GetCardTypeName(cardType) + " ";
            result += Baccarat.GetCardNumName(cardNum);

            return result;
        }
    }
}