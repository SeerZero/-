﻿using NEUVolunteer.Views;
using System;
using System.Collections.Generic;


namespace NEUVolunteer.Services
{
    /// <summary>
    /// 导航服务接口。
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// 导航到某个页面。
        /// </summary>
        /// <param name="pageKey">被导航的页面的关键字</param>
        /// <param name="canBack">导航后是否能够返回当前页面</param>
        void NavigationTo(string pageKey, bool canBack = true);

        void NavigationTo(string pageKey, object parameter);
        /// <summary>
        /// 返回前一个页面
        /// </summary>
        void NavigationBack();
    }

    public static class NavigationServiceConstants
    {

        public static readonly string WelcomePage = nameof(WelcomePage);
        public static readonly string LoginPage = nameof(LoginPage);
        public static readonly string HomePage = nameof(HomePage);
        public static readonly string AdminPage = nameof(AdminPage);
        public static readonly string NewsReadPage = nameof(NewsReadPage);
        public static readonly string ActivityReadPage = nameof(ActivityReadPage);
        public static readonly string ActivityDetailPage = nameof(ActivityDetailPage);
        public static readonly string CreateActivityPage = nameof(CreateActivityPage);
        public static readonly string CreateApplyPage = nameof(CreateApplyPage);
        public static readonly string UpdateApplyPage = nameof(UpdateApplyPage);

        public static readonly Dictionary<string, Type> PageKeyTypeDictionary =
            new Dictionary<string, Type> {
                {WelcomePage, typeof(WelcomePage)},
                {LoginPage,typeof(LoginPage) },
                {AdminPage,typeof(AdminPage) },
                {HomePage,typeof(HomePage) },
                {NewsReadPage, typeof(NewsReadPage) },
                {ActivityReadPage,typeof(ActivityReadPage) },
                {ActivityDetailPage, typeof(ActivityDetailPage)},
                {CreateActivityPage, typeof(CreateActivityPage)},
                {CreateApplyPage, typeof(CreateApplyPage)},
                {UpdateApplyPage, typeof(UpdateApplyPage)}
            };
    }
}
