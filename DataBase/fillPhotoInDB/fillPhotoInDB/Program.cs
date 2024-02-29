using fillPhotoInDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace fillPhotoInDB
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            ApplicationContext db = new ApplicationContext();
            var users = db.User.ToList();

            var images = Directory.GetFiles(@"E:\Программные решения для бизнеса\podgotovka\DataBase\Photo");

            var count = 0;

            foreach (var user in users)
            {
                user.photo = File.ReadAllBytes(images[count]);
                count++;
            }

            db.SaveChanges();
        }
    }
}
