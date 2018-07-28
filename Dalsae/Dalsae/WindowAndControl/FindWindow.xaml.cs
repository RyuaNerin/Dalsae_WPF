﻿using System;
using System.Collections.Concurrent;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dalsae.Data;
using Dalsae.Manager;
using Dalsae.Twitter.Objects;
using static Dalsae.DalsaeManager;
using static Dalsae.DataManager;

namespace Dalsae.WindowAndControl
{
    /// <summary>
    /// FindWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FindWindow : Window
	{
		private ListFindUser listFind { get; set; } = new ListFindUser();
		public FindWindow(Window owner)
		{
			this.Owner = owner;
			ShowInTaskbar = false;
			InitializeComponent();
			listBox.ItemsSource = listFind;
		}

		private void FindFriends(string word)
		{
			if (string.IsNullOrEmpty(word)) return;

			listFind.Clear();
			listBox.SelectedIndex = -1;
			ConcurrentDictionary<long, UserSemi> dicUser = DataInstence.dicFollwing;
			foreach (UserSemi user in dicUser.Values)
			{
				if (user.screen_name.IndexOf(word, StringComparison.CurrentCultureIgnoreCase) > -1
					|| user.name.IndexOf(word, StringComparison.CurrentCultureIgnoreCase) > -1)
					listFind.Add(user);
			}
		}

		private void InputFindId()
		{
			UserSemi user = listBox.SelectedItem as UserSemi;
			if (user == null) return;
			textBox.Text = user.screen_name;
		}

		private void listBoxMentionIds_DoubleClick(object sender, MouseButtonEventArgs e)
		{
			InputFindId();
		}

		private void textBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			FindFriends(textBox.Text);
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			DalsaeInstence.LoadTweet(eTweetPanel.eUser, textBox.Text.Replace("@", "").Replace(" ", ""));
			Close();
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
				Close();
		}

		private void Window_Activated(object sender, EventArgs e)
		{
			textBox.Focus();
		}
	}
}
