using CuratorJournal.Desktop.Helpers;
using CuratorJournal.Desktop.Infrastructure.Commands;
using CuratorJournal.Desktop.Infrastructure.Services;
using CuratorJournal.Desktop.Models;
using CuratorJournal.Desktop.ViewModels.Base;
using System.Windows.Input;

namespace CuratorJournal.Desktop.ViewModels
{
    internal class ProfilePageViewModel : BaseViewModel
    {



		#region ТулТипы


		#region LogOutToolTip : string - ТулТип для выхода

		/// <summary> ТулТип для выхода </summary>
		private string _LogOutToolTip = SettingsHelper.Instance.GetPhrase("Logout");

		/// <summary> ТулТип для выхода </summary>
		public string LogOutToolTip
		{
			get { return _LogOutToolTip; }
			set
			{
				Set(ref _LogOutToolTip, value);
			}
		}
		#endregion

		#endregion

		#region Свойства

		#region CurrentCurator : Curator - Авторизованный куратор

		/// <summary> Авторизованный куратор </summary>
		private Curator _CurrentCurator = new Curator
		{
			CuratorId = 1,
			CategoryName = "Высшая категория",
			Person = new Person
			{
				PersonId = 1,
				Surname = "Comissarov",
				Name = "Alexander",
				Patronymic = "Alexeevich",
				Phone = "9128467",
				Email = "sakdjfh@gmail.com",
			},
			Groups = new List<Group>
			{
				new Group{ GroupId = 1, GroupFullName="ИСП-421п" }
			}
		};

		/// <summary> Авторизованный куратор </summary>
		public Curator CurrentCurator
		{
			get { return _CurrentCurator; }
			set
			{
				Set(ref _CurrentCurator, value);
			}
		}
		#endregion

		#endregion


		#region Команды


		public ICommand LogOutCommand { get; }

		private bool CanLogOutCommandExecute(object p) => true;
		private void OnLogOutCommandExecute(object p)
		{
			if (_dialogService.ShowConfirmation(SettingsHelper.Instance.GetPhrase("ConfirmExit"),
												SettingsHelper.Instance.GetPhrase("Logout")))
				_userDialog.OpenSignInWindow();

		}


		#endregion

		#region Конструктор
		private IUserDialog _userDialog;
		private IDialogService _dialogService;
        public ProfilePageViewModel(IUserDialog userDialog, IDialogService dialog)
        {
            _userDialog = userDialog;
			_dialogService = dialog;
			LogOutCommand = new LambdaCommand(OnLogOutCommandExecute, CanLogOutCommandExecute);
        }
        public ProfilePageViewModel() { }
        #endregion

        
    }
}
