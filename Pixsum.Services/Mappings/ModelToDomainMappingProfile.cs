using AutoMapper;
using Pixsum.Entities;
using Pixsum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixsum.Services.Mappings
{
    public class ModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ModelToDomainMappingProfile";
            }
        }

        protected override void Configure()
        {
            //Ignore mapping null values and create date / update date

            CreateMap<AccountModel, Account>().ForAllMembers(opt => opt.Condition(srs => !srs.IsSourceValueNull));
            //CreateMap<AccountModel, Account>().ForMember(opt => opt.CreatedDate, x => x.Ignore());
            //CreateMap<AccountModel, Account>().ForMember(opt => opt.UpdatedDate, x => x.Ignore());

            //TODO : Finish adding the rest of the models
        }

    }
}