using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_CSharp
{
    interface ISubject
    {
        void Attach(IObserver observer);
        void Notify();
    }
    interface IObserver
    {
        void Update(ISubject subject);
    }
    class Partner : IObserver
    {
        public string NamePartner { get; set; }
        public Partner(string name)
        {
            NamePartner = name;
        }
        public void Update(ISubject subject)
        {

            if (subject is Casting casting)
            {
                Console.WriteLine(string.Format("{0} a été notifié par mail de l'ajout du casting {1}", NamePartner, casting._Name));
                Console.WriteLine();
                Console.Read();
            }
        }

    }
    class Casting : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        public string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; Notify(); }
        }


        public Casting()
        {
            _observers = new List<IObserver>();
        }
        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }
        public void Notify()
        {
            _observers.ForEach(o =>
            {
                o.Update(this);
            });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Casting c1 = new Casting();
            Partner p1 = new Partner("Partenaire 1");
            c1.Attach(p1);
            c1.Name = "Casting 1";
            Console.Read();
            Casting c2 = new Casting();
            Partner p2 = new Partner("Partenaire 2");
            c2.Attach(p2);
            c2.Name = "Casting 2";

        }
    }
}
