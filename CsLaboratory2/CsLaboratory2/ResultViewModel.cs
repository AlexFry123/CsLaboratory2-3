
namespace CsLaboratory2
{
    internal class ResultViewModel
    {
        public bool IsAdult { get; set; }

        public WesternZodiac SunSign { get; set; }

        public ChineseZodiac ChineseSign { get; set; }

        public bool IsBirthday { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }

        public ResultViewModel(Person user)
        {
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            string tmpDate = "";
            tmpDate += user.BirthDate.Day + "."+ user.BirthDate.Month + "." + user.BirthDate.Year;
            BirthDate = tmpDate;
            IsAdult = user.isAdult;
            SunSign = user.sunSign;
            ChineseSign = user.chineseSign;
            IsBirthday = user.isBirthday;
        }

    }
}
