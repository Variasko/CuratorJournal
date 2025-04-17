using CuratorJournal.Desktop.Helpers;
using CuratorJournal.Desktop.Infrastructure.Commands;
using CuratorJournal.Desktop.Infrastructure.Services;
using CuratorJournal.Desktop.ViewModels.Base;
using CuratorJournal.Desktop.Views.Pages;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace CuratorJournal.Desktop.ViewModels
{
    internal class MentorMainWindowViewModel : BaseViewModel
    {


		#region Свойства

		#region Title : string - Заголовок окна

		/// <summary> Заголовок окна </summary>
		private string _Title = SettingsHelper.Instance.GetPhrase("MainWindow");

		/// <summary> Заголовок окна </summary>
		public string Title
		{
			get { return _Title; }
			set
			{
				Set(ref _Title, value);
			}
		}
		#endregion


		#region ToolTips



		#region ProfileToolTip : string - ТулТип для профиля

		/// <summary> ТулТип для профиля </summary>
		private string _ProfileToolTip = SettingsHelper.Instance.GetPhrase("Profile");

		/// <summary> ТулТип для профиля </summary>
		public string ProfileToolTip
		{
			get { return _ProfileToolTip; }
			set
			{
				Set(ref _ProfileToolTip, value);
			}
		}
		#endregion

		#endregion


		#region CurrentPage : Page - Текущая страница

		/// <summary> Текущая страница </summary>
		private Page _CurrentPage;


		/// <summary> Текущая страница </summary>
		public Page CurrentPage
		{
			get { return _CurrentPage; }
			set
			{
				Set(ref _CurrentPage, value);
				OnPropertyChanged(nameof(_CurrentPage));
			}
		}
		#endregion

		#endregion


		#region Команды


		public ICommand ChangePageToProfile { get; }

		private bool CanChangePageToProfileExecute(object p)
		{
			return _CurrentPage is not ProfilePage;
		}
        private void OnChangePageToProfileExecute(object p)
        {
            var page = _userDialog.GetProfilePage();
            CurrentPage.NavigationService.Navigate(page);
			CurrentPage = page;
        }


        public ICommand ChangeToSocialPassportPage { get; }

		private bool CanChangeToSocialPassportPageExecute(object p)
		{
            return _CurrentPage is not SocialPassportPage;
        }
		private void OnChangeToSocialPassportPageExecute(object p)
		{
            var page = _userDialog.GetSocialPassportPage();
            CurrentPage.NavigationService.Navigate(page);
			CurrentPage = page;
        }

		#endregion



		#region Конструкторы
		private IUserDialog _userDialog;
        public MentorMainWindowViewModel(IUserDialog userDialog)
        {
            _userDialog = userDialog;
			_CurrentPage = _userDialog.GetProfilePage();
            ChangePageToProfile = new LambdaCommand(OnChangePageToProfileExecute, CanChangePageToProfileExecute);
			ChangeToSocialPassportPage = new LambdaCommand(OnChangeToSocialPassportPageExecute, CanChangeToSocialPassportPageExecute);
		}
        public MentorMainWindowViewModel() { }
        #endregion
    }
}
