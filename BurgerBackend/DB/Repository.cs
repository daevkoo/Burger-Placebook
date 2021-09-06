using BurgerBackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace BurgerBackend.DB
{
    public class BPRepository
    {
        BBDBContext DBContext;
        public BPRepository(BBDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public List<BurgerPlace> GetBurgerPlaces()
        {
            return DBContext.BurgerPlaces.ToList();
        }

        public BurgerPlace FindBurgerPlaceByName(string f_Name_s)
        {
            return DBContext.BurgerPlaces.FirstOrDefault(r => f_Name_s.Equals(r.m_BPName_s));
        }

        public BurgerPlace FindBurgerPlaceByLocation(Location f_Location_r)
        {
            return DBContext.BurgerPlaces.FirstOrDefault(r => f_Location_r == r.m_Location_r);
        }

        public List<ReviewScore> GetReviewsForBurgerPlace(string f_Name_s)
        {
            var l_ret_l = new List<ReviewScore>();
            var l_BurgerPlace_r = FindBurgerPlaceByName(f_Name_s);
            if(l_BurgerPlace_r != null)
            {
                l_ret_l = DBContext.Reviews.Where(r => r.m_BPID_u64 == l_BurgerPlace_r.m_ID_u64).ToList();
            }

            return l_ret_l;
        }

        public void AddReviewScore(ReviewScore f_Review_r)
        {
            DBContext.Reviews.Add(f_Review_r);
            DBContext.SaveChanges();
        }

        public void DeleteReviewScore(ReviewScore f_Review_r)
        {
            DBContext.Reviews.Remove(f_Review_r);
            DBContext.SaveChanges();
        }

        public void AddPicture(Picture f_Picture_r)
        {
            DBContext.Pictures.Add(f_Picture_r);
            DBContext.SaveChanges();
        }

        public void DeletePicture(Picture f_Picture_r)
        {
            DBContext.Pictures.Remove(f_Picture_r);
            DBContext.SaveChanges();
        }

        public void AddBurgerPlace(BurgerPlace f_BurgerPlace_r)
        {
            DBContext.BurgerPlaces.Add(f_BurgerPlace_r);
            DBContext.SaveChanges();
        }

        public void DeleteBurgerPlace(BurgerPlace f_BurgerPlace_r)
        {
            DBContext.BurgerPlaces.Remove(f_BurgerPlace_r);
            DBContext.SaveChanges();
        }
    }
}