using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWork.CollegeSystem.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        
    }

    public class ChatBox {
        public void Go()
        {
            var mediator = new ConcreateMediator();
            //var c1 = new Colleage1(mediator);
            //var c2 = new Colleage2(mediator);            
            //var c1 = new Colleage1();
            //var c2 = new Colleage2();
            //mediator.Register(c1);
            //mediator.Register(c2);
            //mediator.Colleage1 = c1;
            //mediator.Colleage2 = c2;

            var c1 = mediator.CreateColleage<Colleage1>();
            var c2 = mediator.CreateColleage<Colleage2>();

            c1.Send("Hi");
            c2.Send("Hi");
        }
    }

    public abstract class Mediator {
        public abstract void Send(string message, Colleage colleage);
    }

    public class ConcreateMediator : Mediator
    {
        //knows about all college
        //public Colleage1 Colleage1 { get; set; }
        //public Colleage2 Colleage2 { get; set; }
        private List<Colleage> colleages = new List<Colleage>();

        public void Register(Colleage colleage)
        {
            colleage.SetMediator(this);
        }

        public T CreateColleage<T>() where T : Colleage,new()
        {
            var c = new T();
            c.SetMediator(this);
            this.colleages.Add(c);
            return c;
        }

        public override void Send(string message, Colleage colleage)
        {
            //if (colleage == Colleage1)
            //    Colleage2.HandleNotification("");
            //else
            //    Colleage1.HandleNotification("");

            test("a", "v", "c");

            this.colleages.Where(c => c != colleage).ToList().ForEach(
                c => c.HandleNotification(message)
                );
        }

        public void test(params string[] people) { 
        
        }
    }

    public abstract class Colleage
    {
        protected Mediator mediator;

        //public Colleage(Mediator mediator)
        //{
        //    this.mediator = mediator;
        //}       
        public void SetMediator(Mediator mediator)
        {
            this.mediator = mediator;
        }
        public virtual void Send(string message)
        {
            mediator.Send(message,this);
        }
        public abstract void HandleNotification(string message);
    }

    public class Colleage1 : Colleage
    {
        //public Colleage1(Mediator mediator) : base(mediator)
        //{
        //}

        public override void HandleNotification(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Colleage2 : Colleage
    {
        //public Colleage2(Mediator mediator) : base(mediator)
        //{
        //}

        public override void HandleNotification(string message)
        {
            Console.WriteLine(message);
        }
    }
}
