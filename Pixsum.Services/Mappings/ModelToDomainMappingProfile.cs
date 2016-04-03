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
            //Ignore mapping null values

            CreateMap<AccountModel, Account>().ForAllMembers(opt => opt.Condition(srs => !srs.IsSourceValueNull));
            //TODO : Finish adding the rest of the models
        }

    }
}