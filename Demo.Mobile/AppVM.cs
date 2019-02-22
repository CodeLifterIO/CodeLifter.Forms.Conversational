﻿using CodeLifter.Http;
using CommonServiceLocator;
using MvvmHelpers;
using Demo.Services;
using Demo.ViewModels;
using Unity;
using Unity.ServiceLocation;

namespace Demo
{
    public class AppVM : BaseViewModel
    {
        public static IUnityContainer IOCContainer { get; private set; }
        private ISpeechToText SpeechToTextService { get; set; }
        private static IRestApiClient RestAPIClient = new RestApiClient("https://api.dialogflow.com/v1/");

        public AppVM()
        {
            //init dependent Plugins and components
            InitializeDependencies();

            //set up our IOC container
            InitializeIOCContainer();
        }

        public void InitializeIOCContainer()
        {
            IOCContainer = new UnityContainer();

            var unityServiceLocator = new UnityServiceLocator(IOCContainer);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

            IOCContainer.RegisterInstance(this);
            IOCContainer.RegisterInstance(SpeechToTextService);
            IOCContainer.RegisterInstance(RestAPIClient);
            IOCContainer.RegisterType<IDialogFlowService, PazzService>();
            IOCContainer.RegisterType<InteractionPageVM>();
        }

        public void InitializeDependencies()
        {
            SpeechToTextService = Xamarin.Forms.DependencyService.Get<ISpeechToText>();
        }
    }
}
