using System.Collections.Generic;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;

namespace OngProject.Core.Business
{
    public class MemberBusiness : IMemberBusiness
    {
        private UnitOfWork _unitOfWork;
        public MemberBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Member GetById(int id)
        {
            return _unitOfWork.MemberRepository.GetById(id);
        }

        public List<Member> GetAll()
        {
            return _unitOfWork.MemberRepository.GetAll();
        }

        public void Insert(Member entity)
        {
            _unitOfWork.MemberRepository.Insert(entity);
            _unitOfWork.Save();
        }

        public void Update(Member entity)
        {
            _unitOfWork.MemberRepository.Update(entity);
            _unitOfWork.Save();
        }

        public void Delete(Member entity)
        {
            _unitOfWork.MemberRepository.Delete(entity);
            _unitOfWork.Save();
        }
    }
}
