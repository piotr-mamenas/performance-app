using Web.Tests.FakeData;

namespace Web.Tests
{
    public static class Fakes
    {
        public static FakeAccountData FakeAccountData
        {
            get
            {
                if (FakeAccountData == null)
                {
                    return new FakeAccountData();
                }
                return FakeAccountData;
            }
        }

        public static FakePartnerData FakePartnerData
        {
            get
            {
                if (FakePartnerData == null)
                {
                    return new FakePartnerData();
                }
                return FakePartnerData;
            }
        }
    }
}
