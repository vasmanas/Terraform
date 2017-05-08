using System;

namespace Terraform.Core.Messaging
{
    public abstract class Message
    {
        public Message() : this(Guid.NewGuid())
        {
        }

        public Message(Guid conversationId)
        {
            this.Id = Guid.NewGuid();
            this.ConversationId = conversationId;
        }

        public Guid Id { get; private set; }
        
        public Guid ConversationId { get; private set; }
    }
}
