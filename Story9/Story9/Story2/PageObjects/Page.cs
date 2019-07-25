using Story2.WrapperFactory;
using OpenQA.Selenium.Support.PageObjects;


namespace Story2.PageObjects
{
    public static class Page
    {
       public static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static HomePage Home
        {
            get { return GetPage<HomePage>(); }
        }

        public static LoginPage Login
        {
            get { return GetPage<LoginPage>(); }
        }

        public static AvatarPage Avatar
        {
            get { return GetPage<AvatarPage>(); }
        }

        public static SettingPage Setting
        {
            get { return GetPage<SettingPage>(); }
        }

        public static RegisterPage Register
        {
            get { return GetPage<RegisterPage>(); }
        }

        public static ResetPasswordPage ResetPassword
        {
            get { return GetPage<ResetPasswordPage>(); }
        }

        public static InfoSetPage InfoSet
        {
            get { return GetPage<InfoSetPage>(); }
        }

        public static OrderPage Order
        {
            get { return GetPage<OrderPage>(); }
        }

        public static InfoMgtPage InfoMgt
        {
            get { return GetPage<InfoMgtPage>(); }
        }

    }
}
