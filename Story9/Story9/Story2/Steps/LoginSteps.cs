using OpenQA.Selenium;
using Story2.PageObjects;
using Story2.WrapperFactory;
using TechTalk.SpecFlow;

namespace Story2.Steps
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"I am in login page")]
        public void GivenIAmInLoginPage()
        {
            BrowserFactory.InitBrowser();
            BrowserFactory.LoadApplication();
            Page.Home.SelectLogin();
        }

        [Given(@"I am already in login page")]
        public void GivenIAmAlreadyInLoginPage()
        {
            BrowserFactory.InitBrowser();
            BrowserFactory.LoadApplication();
            Page.Home.SelectLogin();
            Page.Login.ValidLogin();
        }


        [When(@"I input the valid user application")]
        public void WhenIInputTheValidUserApplication()
        {
            Page.Login.ValidLogin();
        }

        [When(@"I input the valid user application and select Remember Me")]
        public void WhenIInputTheValidUserApplicationAndSelectRememberMe()
        {
            Page.Login.SelectRememberMe();
        }

        [When(@"I input the invalid user application")]
        public void WhenIInputTheInvalidUserApplication()
        {
            Page.Login.InvaildLogin();
        }

        [When(@"I click logut button")]
        public void WhenIClickLogutButton()
        {
            Page.Avatar.LogoutAvatar();
        }

        [Then(@"I can login and see avatar image")]
        public void ThenICanLoginAndSeeAvatarImage()
        {
            Page.Avatar.AssertAvatarImage();
            BrowserFactory.CloseAllDriver();
        }


        [Then(@"I cannot login and see error messages")]
        public void ThenICannotLoginAndSeeErrorMessages()
        {
            Page.Login.AssertError();
            BrowserFactory.CloseAllDriver();
        }

        [Then(@"I can logout and see login screen")]
        public void ThenICanLogoutAndSeeLoginScreen()
        {
            Page.Avatar.AssertLoginScreen();
            BrowserFactory.CloseAllDriver();
        }

        [Given(@"I am already in picture uploading page")]
        public void GivenIAmAlreadyInPictureUploadingPage()
        {
            BrowserFactory.InitBrowser();
            BrowserFactory.LoadApplication();
            Page.Home.SelectLogin();
            Page.Login.ValidLogin();
            Page.Avatar.ClickSetting();
        }

        [When(@"I upload a new picture")]
        public void WhenIUploadANewPicture()
        {
            Page.Setting.GoPicUpload();
        }

        [Then(@"I can see a new avatar icon")]
        public void ThenICanSeeANewAvatarIcon()
        {
            Page.Avatar.AssertAvatarImage();
            BrowserFactory.CloseAllDriver();
        }

        [Given(@"I am already in register page")]
        public void GivenIAmAlreadyInRegisterPage()
        {
            BrowserFactory.InitBrowser();
            BrowserFactory.LoadApplication();
            Page.Home.SelectLogin();
            Page.Login.GoRegisterPage();
        }

        [When(@"I input invalid register information")]
        public void WhenIInputInvalidRegisterInformation()
        {
            Page.Register.InputInvalidRegister();          
        }

        [Then(@"I can see error message")]
        public void ThenICanSeeErrorMessage()
        {
            Page.Register.AssertInvalidRegister();
            BrowserFactory.CloseAllDriver();
        }

        [Given(@"I am already in reset password page")]
        public void GivenIAmAlreadyInResetPasswordPage()
        {
            BrowserFactory.InitBrowser();
            BrowserFactory.LoadApplication();
            Page.Home.SelectLogin();
            Page.Login.GoFindPassword();
        }

        [When(@"I enter ""(.*)""")]
        public void WhenIEnter(string wrongEmails)
        {
            Page.ResetPassword.GoResetError(wrongEmails);
        }

        [Then(@"I can see ""(.*)"" of resetting")]
        public void ThenICanSeeOfResetting(string errorMessage)
        {
            Page.ResetPassword.GoResetAssert(errorMessage);
        }


        [Given(@"I am already in basic info setting page")]
        public void GivenIAmAlreadyInBasicInfoSettingPage()
        {
            BrowserFactory.InitBrowser();
            BrowserFactory.LoadApplication();
            Page.Home.SelectLogin();
            Page.Login.ValidLogin();
            Page.Avatar.ClickSetting();
        }

        [When(@"I update info and click save button")]
        public void WhenIUpdateInfoAndClickSaveButton()
        {
            Page.InfoSet.ProfileUpdate();
        }

        [Then(@"I can see alert success message")]
        public void ThenICanSeeAlertSuccessMessage()
        {
            Page.InfoSet.UpdateAssert();
            BrowserFactory.CloseAllDriver();
        }

        [When(@"I entre error profile info")]
        public void WhenIEntreErrorProfileInfo()
        {
            Page.InfoSet.ErrorInput();
        }

        [Then(@"the error message as below should be seen")]
        public void ThenTheErrorMessageAsBelowShouldBeSeen()
        {
            Page.InfoSet.ErrorMsgAssert();
            BrowserFactory.CloseAllDriver();
        }




        [Given(@"I am already in course order page")]
        public void GivenIAmAlreadyInCourseOrderPage()
        {
            BrowserFactory.InitBrowser();
            BrowserFactory.LoadApplication();
            Page.Home.SelectLogin();
            Page.Login.GoAdminLogin();
            Page.Order.GoCourseOrderPage();
        }

        [When(@"I click search buttton")]
        public void WhenIClickSearchButtton()
        {
            Page.Order.GoSearch();
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            Page.Order.GoSearch();
        }


        [Then(@"I can see some orders")]
        public void ThenICanSeeSomeOrders()
        {
            Page.Order.AssertDefaultSearch();
            BrowserFactory.CloseAllDriver();
        }

        [Given(@"I am already in class order page")]
        public void GivenIAmAlreadyInClassOrderPage()
        {
            BrowserFactory.InitBrowser();
            BrowserFactory.LoadApplication();
            Page.Home.SelectLogin();
            Page.Login.GoAdminLogin();
            Page.Order.GoClassOrderPage();
        }


        [When(@"I search for course order through filters")]
        public void WhenISearchForCourseOrderThroughFilters()
        {
            Page.Order.DoCourseSearch();
            Page.Order.GoSearch();
        }

        [Then(@"I can see actual result match expected result")]
        public void ThenICanSeeActualResultMatchExpectedResult()
        {
            Page.Order.AssertSearch();
            BrowserFactory.CloseAllDriver();
        }

        [When(@"I search for class order through filters")]
        public void WhenISearchForClassOrderThroughFilters()
        {
            Page.Order.DoClassSearch();
            Page.Order.GoSearch();
        }




        [Given(@"I am already in info management page")]
        public void GivenIAmAlreadyInInfoManagementPage()
        {
            BrowserFactory.InitBrowser();
            BrowserFactory.LoadApplication();
            Page.Home.SelectLogin();
            Page.Login.GoAdminLogin();
            Page.InfoMgt.GoInfoMgtPage();
        }

        [When(@"I search item based on category,keyword,property and status")]
        public void WhenISearchItemBasedOnCategoryKeywordPropertyAndStatus()
        {
            Page.InfoMgt.DoFilterSearch();
        }

        [Then(@"I can see search result match expected result")]
        public void ThenICanSeeSearchResultMatchExpectedResult()
        {
            Page.InfoMgt.AssertFilterResult();
            BrowserFactory.CloseAllDriver();
        }

        [When(@"I change the status of an article")]
        public void WhenIChangeTheStatusOfAnArticle()
        {
            Page.InfoMgt.DoStatusChange();
        }

        [Then(@"I can see updated status")]
        public void ThenICanSeeUpdatedStatus()
        {
            Page.InfoMgt.AssertStatusUpdate();
        }

        [Then(@"I do vice verse change the status of the article")]
        public void ThenIDoViceVerseChangeTheStatusOfTheArticle()
        {
            Page.InfoMgt.DoStatusChange();
        }

        [Then(@"I can see updated status again")]
        public void ThenICanSeeUpdatedStatusAgain()
        {
            Page.InfoMgt.AssertStatusUpdate();
            BrowserFactory.CloseAllDriver();
        }


        [Given(@"I am in article category page")]
        public void GivenIAmInArticleCategoryPage()
        {
            BrowserFactory.InitBrowser();
            BrowserFactory.LoadApplication();
            Page.Home.SelectLogin();
            Page.Login.GoAdminLogin();
            Page.InfoMgt.GoInfoMgtPage();
            Page.InfoMgt.GoArticlePage();
        }

        [When(@"I add new category")]
        public void WhenIAddNewCategory()
        {
            Page.InfoMgt.DoAddCategory();
        }

        [Then(@"I can see new added category on the UI")]
        public void ThenICanSeeNewAddedCategoryOnTheUI()
        {
            Page.InfoMgt.AssertAddedCategory();
            Page.InfoMgt.DoDeleteAdd();
            BrowserFactory.CloseAllDriver();
        }

        [When(@"I edit the name of new category")]
        public void WhenIEditTheNameOfNewCategory()
        {
            Page.InfoMgt.DoEditCategory();
        }

        [Then(@"I can see new name of category on the UI")]
        public void ThenICanSeeNewNameOfCategoryOnTheUI()
        {
            Page.InfoMgt.AssertChangedName();
            Page.InfoMgt.DoDeleteAdd();
            BrowserFactory.CloseAllDriver();
        }






    }
}
