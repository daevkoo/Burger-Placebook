using System;
using BurgerBackend.Models;

namespace BurgerBackend.DTO
{
    public class BurgerPlaceDTO
    {
        public BurgerPlaceDTO(BurgerPlace f_BurgerPlace_r)
        {
            m_BPName_s = f_BurgerPlace_r.m_BPName_s;
            m_Location_r = f_BurgerPlace_r.m_Location_r;
            m_Information_s = f_BurgerPlace_r.m_Information_s;
            m_OpeningTimes_s = f_BurgerPlace_r.m_OpeningTimes_s;
        }
        public string m_BPName_s { get; set; }
        public Location m_Location_r { get; set; }
        public string m_Information_s { get; set; }
        public string m_OpeningTimes_s { get; set; }
    }

    public class ReviewScoreDTO
    {
        public ReviewScoreDTO(ReviewScore f_ReviewScore_r)
        {
            m_UserIdentification_s = f_ReviewScore_r.m_UserIdentification_s;
            m_SumScore_f = f_ReviewScore_r.m_SumScore_f;
            m_Taste_f = f_ReviewScore_r.m_Taste_f;
            m_Texture_f = f_ReviewScore_r.m_Texture_f;
            m_VisualRepresentation_f = f_ReviewScore_r.m_VisualRepresentation_f;
            m_CreationTime_r = f_ReviewScore_r.m_CreationTime_r;
        }
        public string m_UserIdentification_s { get; set; }
        public float m_SumScore_f { get; set; }
        public float m_Taste_f { get; set; }
        public float m_Texture_f { get; set; }
        public float m_VisualRepresentation_f { get; set; }
        public DateTime m_CreationTime_r { get; set; }
    }

    public class PictureDTO
    {
        public PictureDTO(Picture f_Picture_r)
        {
            m_ReviewScoreID_u64 = f_Picture_r.m_ReviewScoreID_u64;
            m_Path_s = f_Picture_r.m_Path_s;
        }
        public ulong m_ReviewScoreID_u64 { get; set; }
        public string m_Path_s { get; set; }
    }
}
