namespace _09_Property
{
    internal class Program
    {
        class GeneralClass      //일반 클래스의 get/set
        {
            private int field;
            public int GetMyField() { return field; }
            public void SetMyField(int newField) { this.field = newField; }
        }

        class PropertyClass      //프로퍼티를 이용
        {
            private int field;
            public int MyField
            {
                get
                {
                    return field;
                }
                set
                {
                    field = value;
                }
            }
        }

        //자동구현 프로퍼티
        class NameCard
        {
            private string name;
            private string phoneNumber;

            public string Name { get; set; }
            public string PhoneNumber { get; set; }
        }

        //생성자 프로퍼티
        class BirthdatInfo
        {
            public string Name { get; set; }
            public DateTime Birthday { get; set; }
            
        }
        //인터페이스 프로퍼티
        interface IProduct
        {
            string ProductName
            {
                get; set;
            }
        }
        class Product1 : IProduct        //파생 클래스에서 반드시 구현
        {
            private string productName;
            public string ProductName
            {
                get { return productName; }
                set { productName = value; }
            }
        }
        class Product2 : IProduct       //두번째 방법
        {
            public string ProductName { get; set; }
        }
        class Product3 : IProduct       //세번째 방법
        {
            public string ProductName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        }

        static void Main(string[] args)
        {
            BirthdatInfo info = new BirthdatInfo()
            {
                Name = "서현",
                Birthday = new DateTime(1995,03,02)
            };

            //무명 형식의 인스턴스
            var myInstance = new { Name = "나", Age = "16" };
        }

    }
}
