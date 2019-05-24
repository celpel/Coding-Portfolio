package chatroom.server;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.HashSet;
import java.util.Set;
import java.util.Vector;

public class Server
{

    // -- assign each client connection an ID. Just increment for now
    private int nextId = 0;

    // -- the socket that waits for client connections
    private ServerSocket serversocket;

    // -- the port number used for client communication
    private static final int PORT = 8000;

    // -- list of active client threads by ID number
    private Vector<ConnectionThread> clientconnections;
    private Set<String> usernames;

    public int getPort()
    {
        return PORT;
    }

    public Server()
    {

        // -- construct the list of active client threads
        clientconnections = new Vector<>();
        usernames = new HashSet<>();
        // -- listen for incoming connection requests
        listen();

    }

    public void peerconnection(Socket socket)
    {
        // -- when a client arrives, create a thread for their communication
        ConnectionThread connection = new ConnectionThread(nextId, socket, this);

        // -- add the thread to the active client threads list
        clientconnections.add(connection);

        // -- start the thread
        connection.start();

        // -- place some text in the area to let the server operator know what is going on
        System.out.println("SERVER: connection received for id " + nextId + "\n");
        ++nextId;
    }

    // -- called by a ServerThread when a client is terminated
    public void removeID(ConnectionThread c)
    {
        clientconnections.remove(c);       // remove thread from connections on disconnect
        usernames.remove(c.getUsername()); // remove username from list
        System.out.println("SERVER: connection closed for client id " + c.getId() + "\n");
    }
    
    public void addUsername(ConnectionThread c)
    {
        usernames.add(c.getUsername());
    }

    private void listen()
    {
        try
        {
            // -- open the server socket
            serversocket = new ServerSocket(getPort());

            // -- server runs until we manually shut it down
            while (true)
            {
                // -- block until a client comes along
                Socket socket = serversocket.accept();

                // -- connection accepted, create a peer-to-peer socket
                //    between the server (thread) and client
                peerconnection(socket);
            }
        }
        catch (IOException e)
        {
            e.printStackTrace();
            System.exit(1);

        }
    }
    
    public void sendMsgToAll(String message, ConnectionThread sender)
    {
        clientconnections.remove(sender);
        for(ConnectionThread cc : clientconnections)
        {
            cc.writeToBuffer(message);
        }
        clientconnections.add(sender);
    }

    public static void main(String args[])
    {
        // -- instantiate the server anonymously
        //    no need to keep a reference to the object since it will run in its own thread
        new Server();
    }

}
