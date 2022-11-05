using System;

namespace Client
{
    public enum UserEvent
    {
        INSCRIERE
    };
    
    public class ChatUserEventArgs : EventArgs
    {
        private readonly UserEvent userEvent;
        private readonly Object data;

        public ChatUserEventArgs(UserEvent userEvent, object data)
        {
            this.userEvent = userEvent;
            this.data = data;
        }

        public UserEvent UserEventType
        {
            get { return userEvent; }
        }

        public object Data
        {
            get { return data; }
        }
    }
}