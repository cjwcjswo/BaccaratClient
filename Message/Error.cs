using System.Collections.Generic;

namespace Protocol
{
    public static class Error
    {
        public static readonly Dictionary<short, string> ErrorDic =
            new Dictionary<short, string>
            {
                [ERROR_CODE_NONE] = "",
                [ERROR_CODE_DECODING_FAIL] = "패킷 디코딩 실패",
                [ERROR_CODE_ENCODING_FAIL] = "서버에서 패킷 인코딩 실패했습니다",
                [ERROR_CODE_INVALID_SESSION] = "올바르지 않는 세션입니다",
                [ERROR_CODE_NICKNAME_LENGTH_OVER] = "닉네임 길이를 초과하였습니다.",
                [ERROR_CODE_ALREADY_LOGIN_USER] = "이미 로그인 상태입니다.",
                [ERROR_CODE_NOT_LOGIN_USER] = "로그인 하지 않은 상태입니다.",
                [ERROR_CODE_USER_NOT_IN_THE_ROOM] = "방에 들어가있지 않습니다.",
                [ERROR_CODE_ALREADY_USER_IN_THE_ROOM] = "이미 방 안에 있습니다.",
                [ERROR_CODE_INVALID_ROOM_NUM] = "올바르지 않은 방 번호입니다.",
                [ERROR_CODE_ROOM_IS_FULL] = "방 최대 인원을 초과했습니다.",
                [ERROR_CODE_DUPLICATE_ROOM_USER] = "중복 입장한 상태입니다.",
                [ERROR_CODE_YOU_ALREADY_BETTING] = "이미 베팅했습니다.",
                [ERROR_CODE_ALREADY_GAME_START] = "이미 시작한 게임입니다."
            };

        public const int
            ERROR_CODE_NONE = 0,
            ERROR_CODE_DECODING_FAIL = 301,
            ERROR_CODE_ENCODING_FAIL = 302,
            ERROR_CODE_INVALID_SESSION = 303,
            ERROR_CODE_NICKNAME_LENGTH_OVER = 304,
            ERROR_CODE_ALREADY_LOGIN_USER = 305,
            ERROR_CODE_NOT_LOGIN_USER = 306,
            ERROR_CODE_USER_NOT_IN_THE_ROOM = 307,
            ERROR_CODE_ALREADY_USER_IN_THE_ROOM = 308,
            ERROR_CODE_INVALID_ROOM_NUM = 309,
            ERROR_CODE_ROOM_IS_FULL = 310,
            ERROR_CODE_DUPLICATE_ROOM_USER = 311,
            ERROR_CODE_YOU_ALREADY_BETTING = 312,
            ERROR_CODE_ALREADY_GAME_START = 313;
    }
}