using AutoMapper;
using Pixsum.API.Models;
using Pixsum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pixsum.API.Mappings
{
    public class DomainToAPIModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToAPIModelMappingProfile";
            }
        }

        protected override void Configure()
        {
            CreateMap<Account, AccountModel>();
            //TODO : Finish adding the rest of the models
        }

    }
}