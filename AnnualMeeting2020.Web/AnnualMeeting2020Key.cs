namespace AnnualMeeting2020.Web
{
    public class AnnualMeeting2020Key
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public const string SESSION_USER_KEY = "CurrUser";

        /// <summary>
        /// 是否打开
        /// </summary>
        public const string CACHE_IsMessage_KEY = "IsMessage";

        /// <summary>
        /// 弹幕列表
        /// </summary>
        public const string CACHE_MESSAGE_KEY = "MessageList";

        /// <summary>
        /// 发送弹幕
        /// </summary>
        public const string CACHE_SEND_MESSAGE_KEY = "SendMessage";

        /// <summary>
        /// 表演表类型
        /// </summary>
        public const string CACHE_CURRENT_PLAYER_KEY = "CurrentPlayer";

        /// <summary>
        /// 当前选手票数
        /// </summary>
        public const string CACHE_CURRENT_TICKET_KEY = "CurrentTicketCount";

        /// <summary>
        /// 票数
        /// </summary>
        public const int TICKET_COUNT = 7;

        /// <summary>
        /// 发送弹幕间隔
        /// </summary>
        public const int TIME_INTERVAL = 7;

        /// <summary>
        /// 分隔符
        /// </summary>
        public const string SPLIT_CHAR = "-";

    }
}