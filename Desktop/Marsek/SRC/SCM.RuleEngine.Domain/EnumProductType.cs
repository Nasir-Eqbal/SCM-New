using System;
using System.Collections.Generic;
using System.Text;

namespace SCM.RuleEngine.Domain
{
    public enum ProductTypes
    {
        PhysicalProduct,
        Books,
        NewMembership,
        UpgradeMembership,
        Videos

    }

    public enum PackingSlipType
    {
        SlipForShipping,
        SlipForRoyalty
    }
}
