using System;
using System.Collections.Generic;
using Protocol;

namespace BaccaratClient
{
    public class User
    {
        public static readonly User MyInfo = new User();
        public static List<User> CurrentRoomUserList;
        public string TempNickname { get; set; }

        public string Nickname { get; set; }

        public int CurrentRoom { get; set; }

        public ulong UniqueId { get; set; }

        public User()
        {
            
        }
        
        public User(string nickname, ulong uniqueId)
        {
            Nickname = nickname;
            UniqueId = uniqueId;
        }
        
        public void UserLogin(string nickname)
        {
            Nickname = nickname;
        }

        public static void NewCurrentRoomUserList(List<User> userList)
        {
            CurrentRoomUserList = userList;
        }

        public static void AddUserInfo(User user)
        {
            CurrentRoomUserList?.Add(user);
        }
    }
}