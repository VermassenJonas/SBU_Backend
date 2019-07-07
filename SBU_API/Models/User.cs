using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBU_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime JoinDate { get; set; }
        public ICollection<MonsterUser> MonsterUsers { get; set; }

        public User()
        {
            MonsterUsers = new List<MonsterUser>();
        }

        public void addToCollection(Monster monster)
        {
            MonsterUser mu = new MonsterUser()
            {
                Monster = monster,
                MonsterId = monster.Id,
                User = this,
                UserId = this.Id
            };
            MonsterUsers.Add(mu);
        }
        public void removeFromCollection(Monster monster)
        {
            MonsterUsers = MonsterUsers.Where(mu => mu.Monster.Id != monster.Id).ToList();
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            else
            {
                if (Email.Equals(((User) obj).Email))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            
            return Email.GetHashCode() * 31 + 47;
        }
    }
}
