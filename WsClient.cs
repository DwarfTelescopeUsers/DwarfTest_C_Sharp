using System;
using System.Text;
using System.Threading;
using System.Net.WebSockets;

namespace DwarfApp
{
    public class WsClient
    {

        public WsClient()
        {

        }

        public static async void SendMessage(string msg)
        {
            ClientWebSocket ws = null;
            try
            {
                using (ws = new ClientWebSocket())
                {
                    await ws.ConnectAsync(new Uri("ws://192.168.0.67:9900"), CancellationToken.None);

                    byte[] messageBytes = Encoding.UTF8.GetBytes(msg);

                    await ws.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);

                    // Receive a message from the server
                    byte[] buffer = new byte[1024];
                    WebSocketReceiveResult result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine("Received message: " + receivedMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
            finally
            {
                if (ws != null)
                {
                    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Connection closed by client", CancellationToken.None);
                    ws.Dispose();
                }
            }
            // Close the WebSocket connection
            // 
        }

        public void OpenWACamera()
        {
            try
            {
                var msg = $"{{\"interface\":10000,\"camId\":1}}";
                SendMessage(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        public void CloseWACamera()
        {
            try
            {
                var msg = $"{{\"interface\":10017,\"camId\":1}}";
                SendMessage(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        public void MoveCamera(int motor, int dirn)
        {
            try
            {
                var msg = $"{{" +
                        $"\"interface\":10100," +
                        $"\"id\":{motor}," +
                        $"\"mode\":1," +
                        $"\"mstep\":2," +
                        $"\"speed\":200," +
                        $"\"direction\":{dirn}," +
                        $"\"pulse\":2," +
                        $"\"accelStep\":100" +
                    $"}}";
                SendMessage(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        public void StopMove(int motor)
        {
            try
            {
                var msg = $"{{" +
                        $" \"interface\":10101, " +
                        $"\"id\":{motor}, " +
                        $"\"decelStep\":100 " +
                    $"}}";
                SendMessage(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }
    }
}