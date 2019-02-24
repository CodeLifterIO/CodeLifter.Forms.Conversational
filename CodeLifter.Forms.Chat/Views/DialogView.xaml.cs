﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CodeLifter.Forms.Chat.Models;
using Xamarin.Forms;

namespace CodeLifter.Forms.Chat.Views
{
    public partial class DialogView : ContentView
    { 
        public static readonly BindableProperty MessagesSourceProperty = BindableProperty.Create(
          "MessagesSource", 
          typeof(IList<ChatMessage>),
          typeof(DialogView), 
          new ObservableCollection<ChatMessage>()); 

        public IList<ChatMessage> MessagesSource
        {
            get { return (IList<ChatMessage>)GetValue(MessagesSourceProperty); }
            set { SetValue(MessagesSourceProperty, value); }
        }

        public DialogView()
        {
            InitializeComponent();
        }
    }
}
