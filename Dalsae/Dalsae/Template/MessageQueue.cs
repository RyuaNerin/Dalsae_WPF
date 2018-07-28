using System.Collections.Generic;

namespace Dalsae.Template
{
    public class MessageQueue:BaseNoty
	{
		//private const int conShowTime = 2;
		//private DateTime time;
		private Queue<string> queue = new Queue<string>();
		private bool _isShowMessage;
		public bool isShowMessage { get { return _isShowMessage; } set { _isShowMessage = value; OnPropertyChanged("isShowMessage"); } }
		private string _message = string.Empty;
		public string message { get { return _message; } set { _message = value; OnPropertyChanged("message"); } }
		public void AddMessage(string message)
		{
			queue.Enqueue(message);
		}
		//메인윈도우에서 시간 체크할때마다 호출
		//return: true: 메시지가 남아있고 출력했음, false: 메시지큐가 없음
		public bool NextMessage()
		{
			if (queue.Count == 0)
			{
				isShowMessage = false;
				message = string.Empty;
				return false;
			}
			else
			{
				message = queue.Dequeue();
				isShowMessage = true;
				return true;
			}
		}
		//public void CheckMessageByDispatcherTimer(object sender, EventArgs e)
		//{
		//	if (isShowMessage == false) return;

		//	TimeSpan timeSpan = DateTime.Now - time;
		//	if (timeSpan.TotalSeconds < conShowTime) return;//메시지를 보여주는 시간이 안 됐으면 종료
		//	if (queue.Count != 0)
		//	{
		//		time = DateTime.Now;
		//		message = queue.Dequeue();
		//	}
		//	else
		//	{
		//		isShowMessage = false;
		//		message = string.Empty;
		//	}
		//}
	}

}
