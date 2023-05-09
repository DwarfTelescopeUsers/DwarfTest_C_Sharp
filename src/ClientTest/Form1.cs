
using ClientTest.Models;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClientTest
{
    public partial class Form1 : Form
    {
        // "wss://localhost:7122/ws"
        private static readonly string uri = "ws://192.168.1.162:9900";

        private static readonly JsonSerializerOptions jsoptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnPowerOn_Click(object sender, EventArgs e)
        {
            D2Message d2Message = new()
            {
                Interface = 10001,
                CamId = 0
            };

            D2Message? response = await SendMessage(d2Message);
        }

        public static async Task<D2Message?> SendMessage(D2Message d2Message)
        {
            try
            {
                string sendMessage = JsonSerializer.Serialize(d2Message, jsoptions);
                Debug.WriteLine($"Send message: {sendMessage}");

                using ClientWebSocket webSocket = new();
                await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);

                byte[] sendBuffer = Encoding.UTF8.GetBytes(sendMessage);
                await webSocket.SendAsync(new ArraySegment<byte>(sendBuffer), WebSocketMessageType.Text, true, CancellationToken.None);

                byte[] receiveBuffer = new byte[1024];
                WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
                string receivedMessage = Encoding.UTF8.GetString(receiveBuffer, 0, result.Count);
                Debug.WriteLine($"Received message: {receivedMessage}");

                var receiveD2Message = JsonSerializer.Deserialize<D2Message>(receivedMessage, jsoptions);
                return receiveD2Message;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex}");
                return null;
            }
        }

        private async void BtnRotateAnti_Click(object sender, EventArgs e)
        {
            D2Message d2Message = new()
            {
                Interface = 10100,
                Id = 1,
                Mode = 1,
                MStep = 1,
                Speed = 1000,
                Direction = 0, // Anti-clockwise
                Pulse = 2,
                AccelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
        }

        private async void BtnStop1_Click(object sender, EventArgs e)
        {
            D2Message d2Message = new()
            {
                Interface = 10101,
                Id = 1,
                DecelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
        }

        private async void BtnRotateClock_Click(object sender, EventArgs e)
        {
            D2Message d2Message = new()
            {
                Interface = 10100,
                Id = 1,
                Mode = 1,
                MStep = 1,
                Speed = 1000,
                Direction = 1, // Clockwise
                Pulse = 2,
                AccelStep = 20
            };

            D2Message? response = await SendMessage(d2Message);
        }
    }
}