using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BurgerBackend.Models;
using BurgerBackend.DTO;
using BurgerBackend.DB;

namespace BurgerBackend.Controllers
{
    public class BurgerPlaceController : Controller
    {
        BPRepository m_BurgerPlaceRepo_r;
        public BurgerPlaceController(BPRepository f_BurgerPlaceRepo_r)
        {
            m_BurgerPlaceRepo_r = f_BurgerPlaceRepo_r;
        }

        public List<BurgerPlaceDTO> GetAllBurgerPlaces()
        {
            var l_BPList_l = m_BurgerPlaceRepo_r.GetBurgerPlaces();
            var l_DTOList_l = new List<BurgerPlaceDTO>();
            foreach(var l_BurgerPlace in l_BPList_l)
            {
                var l_BurgerPlaceDTO = new BurgerPlaceDTO(l_BurgerPlace);
                l_DTOList_l.Add(l_BurgerPlaceDTO);
            }
            
            return l_DTOList_l;
            
        }

        public BurgerPlaceDTO FindBurgerPlaceByName(string f_Name_s)
        {
            return new BurgerPlaceDTO(m_BurgerPlaceRepo_r.FindBurgerPlaceByName(f_Name_s));
        }

        public BurgerPlaceDTO FindBurgerPlaceByLocation()
        {
            Location l_MyLocation = new Location();
            return new BurgerPlaceDTO(m_BurgerPlaceRepo_r.FindBurgerPlaceByLocation(l_MyLocation.GetMyLocation()));
        }

        public string GetInformationOfBurgerPlace(string f_Name_s)
        {
            return m_BurgerPlaceRepo_r.FindBurgerPlaceByName(f_Name_s).m_Information_s;
        }

        public string GetOpeningTimesOfBurgerPlace(string f_Name_s)
        {
            return m_BurgerPlaceRepo_r.FindBurgerPlaceByName(f_Name_s).m_OpeningTimes_s;
        }

        public Location GetLocationOfBurgerPlace(string f_Name_s)
        {
            return m_BurgerPlaceRepo_r.FindBurgerPlaceByName(f_Name_s).m_Location_r;
        }

        public List<ReviewScoreDTO> GetReviewsForBurgerPlace(string f_Name_s)
        {
            var l_Reviews_l = m_BurgerPlaceRepo_r.GetReviewsForBurgerPlace(f_Name_s);
            var l_DTOList_l = new List<ReviewScoreDTO>();
            foreach (var l_ReviewScore in l_Reviews_l)
            {
                var l_ReviewScoreDTO = new ReviewScoreDTO(l_ReviewScore);
                l_DTOList_l.Add(l_ReviewScoreDTO);
            }

            return l_DTOList_l;
        }

        public void CreateReviewForBurgerPlace(string f_BurgerPlaceName_s, float f_Taste_f, float f_Texture_f, float f_VisualRepresentation_f, string f_PicturePath_s)
        {
            var l_BurgerPlace_r = m_BurgerPlaceRepo_r.FindBurgerPlaceByName(f_BurgerPlaceName_s);
            var l_NewReviewScore = new ReviewScore(f_Taste_f, f_Texture_f, f_VisualRepresentation_f);
            l_NewReviewScore.m_UserIdentification_s = User.Identity.GetUserId();
            l_NewReviewScore.m_BPID_u64 = l_BurgerPlace_r.m_ID_u64;
            m_BurgerPlaceRepo_r.AddReviewScore(l_NewReviewScore);

            if(!string.IsNullOrEmpty(f_PicturePath_s))
            {
                var l_NewPicture = new Picture(l_NewReviewScore.m_ID_u64, f_PicturePath_s);
                m_BurgerPlaceRepo_r.AddPicture(l_NewPicture);
            }
        }
    }
}
