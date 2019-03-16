using CsLaboratory2.Exceptions;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace CsLaboratory2
{
    internal enum WesternZodiac { Ram, Bull, Twins, Crab, Lion, Virgin, Scales, Scorpion, Archer, Goat, WaterBearer, Fish };
    internal enum ChineseZodiac { Monkey, Rooster, Dog, Pig, Rat, Ox, Tiger, Rabbit, Dragon, Snake, Horse, Goat };

    internal class Person
    {
        private readonly string emailPattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

        private string _email;

        internal readonly bool isAdult;
        internal readonly WesternZodiac sunSign;
        internal readonly ChineseZodiac chineseSign;
        internal readonly bool isBirthday;

        internal string Name { get; set; }
        internal string Surname { get; set; }
        internal DateTime BirthDate { get; set; }

        public Person(string name, string surname, string email, DateTime birthdate)
        {
            Name = name;
            Surname = surname;
            Email = email;
            BirthDate = birthdate;
            isAdult = Adult(BirthDate);
            sunSign = ChooseSign(BirthDate);
            chineseSign = CalcChineseZodiac(BirthDate);
            isBirthday = Birthday(BirthDate);
        }

        public Person(string name, string surname, string email): this(name, surname, email, DateTime.Today)
        {
        }

        public Person(string name, string surname, DateTime birthdate): this(name, surname, "nullmail@ukma.edu.ua", birthdate)
        {
        }

        internal string Email
        {
            get { return _email; }
            set
            {
                if (!Regex.IsMatch(value, emailPattern, RegexOptions.IgnoreCase))
                    throw new WrongEmailException(value);
                _email = value;
            }
        }

        private bool Birthday(DateTime dTime)
        {
            if (dTime.Day == DateTime.Today.Day && dTime.Month == DateTime.Today.Month)
            {
                MessageBox.Show("Happy Birthday!!!");
                return true;
            }
            return false;
        }

        private bool Adult(DateTime dTime)
        {
            int age = DateTime.Today.Year - dTime.Year;
            if (dTime > DateTime.Today.AddYears(-age)) age--;
            if (age >= 135)
                throw new BirthDateInDistantPastException("You can't be so old! Try another date.");
            if (age < 0)
                throw new BirthDateInFutureException("You haven't been born yet! Try another date.");
            return age >= 18;
        }

        private WesternZodiac ChooseSign(DateTime dTime)
        {
            if ((dTime.Day >= 21 && dTime.Month == 3) || (dTime.Day <= 20 && dTime.Month == 4))
                return WesternZodiac.Ram;
            else if ((dTime.Day >= 21 && dTime.Month == 4) || (dTime.Day <= 20 && dTime.Month == 5))
                return WesternZodiac.Bull;
            else if ((dTime.Day >= 21 && dTime.Month == 5) || (dTime.Day <= 20 && dTime.Month == 6))
                return WesternZodiac.Twins;
            else if ((dTime.Day >= 21 && dTime.Month == 6) || (dTime.Day <= 21 && dTime.Month == 7))
                return WesternZodiac.Crab;
            else if ((dTime.Day >= 22 && dTime.Month == 7) || (dTime.Day <= 21 && dTime.Month == 8))
                return WesternZodiac.Lion;
            else if ((dTime.Day >= 22 && dTime.Month == 8) || (dTime.Day <= 21 && dTime.Month == 9))
                return WesternZodiac.Virgin;
            else if ((dTime.Day >= 22 && dTime.Month == 9) || (dTime.Day <= 21 && dTime.Month == 10))
                return WesternZodiac.Scales;
            else if ((dTime.Day >= 22 && dTime.Month == 10) || (dTime.Day <= 21 && dTime.Month == 11))
                return WesternZodiac.Scorpion;
            else if ((dTime.Day >= 22 && dTime.Month == 11) || (dTime.Day <= 21 && dTime.Month == 12))
                return WesternZodiac.Archer;
            else if ((dTime.Day >= 22 && dTime.Month == 12) || (dTime.Day <= 20 && dTime.Month == 1))
                return WesternZodiac.Goat;
            else if ((dTime.Day >= 22 && dTime.Month == 1) || (dTime.Day <= 20 && dTime.Month == 2))
                return WesternZodiac.WaterBearer;
            else
                return WesternZodiac.Fish;
        }

        private ChineseZodiac CalcChineseZodiac(DateTime birthDate)
        {
            return ((ChineseZodiac)(birthDate.Year % 12));
        }

    }
}
