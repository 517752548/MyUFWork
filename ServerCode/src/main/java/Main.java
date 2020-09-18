import io.vertx.core.Vertx;
import io.vertx.core.buffer.Buffer;
import io.vertx.core.net.NetServer;
import io.vertx.core.net.NetServerOptions;

public class Main {
    public static void main(String[] args) {
        TestSocket();
    }

    private static void TestWebSocket() {

    }

    private static void TestSocket() {
        Vertx vertx = Vertx.vertx();

        //vertx.deployVerticle(MyFirstVerticle.class.getName());

        NetServerOptions netServerOptions = new NetServerOptions().setPort(4321);
        NetServer netServer = vertx.createNetServer(netServerOptions);


        netServer.connectHandler(netSocket -> {
            netSocket.handler(buffer -> {
                System.out.println("I received some bytes: " + buffer.length());
                Buffer buffers = Buffer.buffer().appendFloat(12.34f).appendInt(123);
                netSocket.write(buffers);

// 以UTF-8的编码方式写入一个字符串
                netSocket.write("some data");
            });
        });
        netServer.listen();
    }
}
