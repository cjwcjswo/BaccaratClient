using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using Google.Protobuf;
using Protocol;

namespace BaccaratClient
{
    
    public partial class RoomForm : Form
    {
        private readonly BcApp _bcApp;
        private readonly NetworkClient _client;
        public RoomForm(BcApp bcApp, NetworkClient client)
        {
            InitializeComponent();
            _bcApp = bcApp;
            _client = client; 
            FormClosing += form_Closing;
        }

        public void SetRoomNumText(int roomNum)
        {
            roomNumLabel.Text = roomNum.ToString();
        }

        public void AddUserToUserListBox(User user)
        {
            userListBox.Items.Add(user);
        }

        public void AddChatMessage(string chat)
        {
            chatBox.Items.Add(chat);
            chatBox.SelectedIndex = chatBox.Items.Count - 1;
        }

        public void RemoveUserToUserListBox(ulong sessionUniqueId)
        {
            foreach(var item in userListBox.Items)
            {
                var user = (User) item;
                if (user.UniqueId != sessionUniqueId) continue;
                userListBox.Items.Remove(item);
                break;
            }
        }

        public void GameStartUiChange(bool buttonEnable, bool bettingListClear)
        {
            bankerBettingButton.Enabled = buttonEnable;
            playerBettingButton.Enabled = buttonEnable;
            drawBettingButton.Enabled = buttonEnable;

            if (bettingListClear)
            {
                bettingListBox.Items.Clear();
            }
        }

        public void AddUserToBettingList(string bettingString)
        {
            bettingListBox.Items.Add(bettingString);
        }

        public void SetUserCardImage(uint userType, uint round, uint cardType, uint cardNum)
        {
            PictureBox picture;
            if (userType == Baccarat.BACCARAT_TYPE_PLAYER)
            {
                switch (round)
                {
                    case 0:
                        picture = p1Box;
                        break;
                    case 1:
                        picture = p2Box;
                        break;
                    default:
                        picture = p3Box;
                        break;
                }
            }
            else
            {
                switch (round)
                {
                    case 0:
                        picture = b1Box;
                        break;
                    case 1:
                        picture = b2Box;
                        break;
                    default:
                        picture = b3Box;
                        break;
                }
            }

            var img = (Bitmap)Properties.Resources.ResourceManager.GetObject(Baccarat.GetCardImageName(cardType, cardNum));
            picture.Image = img;
        }

        public void AddTextToLogBox(string log)
        {
            logBox.Items.Add(log);
            logBox.SelectedIndex = logBox.Items.Count - 1;
        }

        public void ClearImage()
        {
            p1Box.Image = null;
            p2Box.Image = null;
            p3Box.Image = null;
            b1Box.Image = null;
            b2Box.Image = null;
            b3Box.Image = null;
        }
        
        private void form_Closing(object sender, FormClosingEventArgs e)
        {
            _bcApp.Close();
            Application.Exit();
        }
        
        private void enterBox_Click(object sender, EventArgs e)
        {
            SendChatMessage();
        }

        private void inputBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendChatMessage();
            }
        }

        private void SendChatMessage()
        {
            var request = new RoomChatRequest
            {
                Message = chatInputBox.Text
            };
            _client.Send(Packet.EncodingPacket(PacketId.PACKET_ID_ROOM_CHAT_REQ, Error.ERROR_CODE_NONE, request.ToByteArray()));
            chatInputBox.Text = "";
        }
        
        
        private void playerBettingButton_Click(object sender, EventArgs e)
        {
            BettingButtonClick(Baccarat.BACCARAT_TYPE_PLAYER);
        }

        private void drawBettingButton_Click(object sender, EventArgs e)
        {
            BettingButtonClick(Baccarat.BACCARAT_TYPE_DRAW);
        }

        private void bankerBettingButton_Click(object sender, EventArgs e)
        {
            BettingButtonClick(Baccarat.BACCARAT_TYPE_BANKER);
        }
        
        private void BettingButtonClick(uint bettingType)
        {
            bankerBettingButton.Enabled = false;
            playerBettingButton.Enabled = false;

            var request = new BettingRequest
            {
                BettingType = bettingType
            };
            _client.Send(Packet.EncodingPacket(PacketId.PACKET_ID_GAME_BETTING_REQ, Error.ERROR_CODE_NONE, request.ToByteArray()));
        }
    }
}