using System;   //core namespace in .NET contains fundamental classes 
using System.Collections.Generic;  // This gives access to generic collection classes, List<T>


namespace InterviewPrep  //helps you organize classes, interfaces, and other types
{
    public interface IMessageService
    {
        void SendMessage(string message);  //method signature for sending a message
    }
    public class EmailMessage : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Email sent with message: {message}");
        }
    }
    public class Notification
    {
        private readonly IMessageService _messageService;  //readonly field to hold the message service

        // dependancy injection
        public Notification(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public void Notify(string message)
        {
            _messageService.SendMessage(message);  //use the message service to send a notification
        }
    }

    // Adding the Program class with a Main method as an entry point
    class Program
    {
        static void Main()
        {
            
            IMessageService service = new EmailMessage();
            Notification notifier = new Notification(service);
            notifier.Notify("Hello via DI!");
        }
    }

}