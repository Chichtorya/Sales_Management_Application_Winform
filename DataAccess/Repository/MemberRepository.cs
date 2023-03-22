using BusinessObject;
using DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public class MemberRepository { 
           private readonly DbContext _dbContext;

    public MemberRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Member> GetMembers()
    {
        return _dbContext.Member.ToList();
    }

    public Member GetMemberById(int id)
    {
        return _dbContext.Member.FirstOrDefault(m => m.MemberId == id);
    }
        public Member Authenticate(string email, string password) => _dbContext.Member.FirstOrDefault(m => m.Email == email && m.Password == password);

        public void AddMember(Member member)
    {
        _dbContext.Member.Add(member);
        _dbContext.SaveChanges();
    }

    public void UpdateMember(Member member)
    {
        _dbContext.Entry(member).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteMember(int id)
    {
        var member = _dbContext.Member.FirstOrDefault(m => m.MemberId == id);
        _dbContext.Member.Remove(member);
        _dbContext.SaveChanges();
    }
}
}