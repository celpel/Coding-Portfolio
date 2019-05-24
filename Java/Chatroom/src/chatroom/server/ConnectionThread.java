package chatroom.server;

import chatroom.database.DBAccounts;
import chatroom.encryption.EncryptionManager;
import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.Socket;
import java.util.logging.Level;
import java.util.logging.Logger;

public class ConnectionThread extends Thread
{

    private boolean go;
    private String name;
    private int id;
    private DBAccounts db;
    private EncryptionManager em;

    // -- the main server (port listener) will supply the socket
    //    the thread (this class) will provide the I/O streams
    //    BufferedReader is used because it handles String objects
    //    whereas DataInputStream does not (primitive types only)
    private BufferedReader datain;
    private DataOutputStream dataout;

    // -- this is a reference to the "parent" Server object
    //    it will be set at time of construction
    private Server server;

    public ConnectionThread(int id, Socket socket, Server server)
    {
        this.server = server;
        this.id = id;
        this.name = Integer.toString(id);
        this.db = new DBAccounts();
        this.em = new EncryptionManager();
        go = true;

        // -- create the stream I/O objects on top of the socket
        try
        {
            datain = new BufferedReader(new InputStreamReader(socket.getInputStream()));
            dataout = new DataOutputStream(socket.getOutputStream());
        }
        catch (IOException e)
        {
            e.printStackTrace();
            System.exit(1);
        }

    }

    public String toString()
    {
        return name;
    }

    public String getname()
    {
        return name;
    }

    public void run()
    {
        // -- server thread runs until the client terminates the connection
        while (go)
        {
            try
            {
                // -- always receives a String object with a newline (\n)
                //    on the end due to how BufferedReader readLine() works.
                //    The client adds it to the user's string but the BufferedReader
                //    readLine() call strips it off
                String command = datain.readLine();
                System.out.println("SERVER receive: " + command);

                command = em.decrypt(command); // to be added

                String[] cmd = command.split("-");
                command = cmd[0];

                switch (command)
                {
                    case "&disconnect":
                        datain.close();
                        server.removeID(this);
                        go = false;
                        break;
                    case "&login":
                        String login = db.verifyAccount(cmd[1], cmd[2]);
                        addUsernameToServer(cmd[1]);
                        writeToBuffer(login);
                        break;
                    case "&register":
                        String register = db.registerAccount(cmd[1], cmd[2], cmd[3]);
                        addUsernameToServer(cmd[1]);
                        writeToBuffer(register);
                        break;
                    case "&msg":
                        StringBuilder message = new StringBuilder();
                        
                        for(int i = 1; i < cmd.length; i++) // append everything after &msg, prevents "-test" from only sending "-"
                        {
                            message.append(cmd[i]);
                        }
                        
                        String msg = em.encrypt(message.toString());
                        this.server.sendMsgToAll(msg, this);
                        break;
                    default:
                        System.out.println("unrecognized command >>" + command + "<<");
                        writeToBuffer(command);
                        break;
                }

            }
            catch (IOException e)
            {
                e.printStackTrace();
                go = false;
            }

        }
        
        try
        {
            datain.close();
            dataout.close();
        }
        catch (IOException ex)
        {
            Logger.getLogger(ConnectionThread.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    // adds username to server so it can be displayed in the username box
    private void addUsernameToServer(String username)
    {
        this.name = username;
        server.addUsername(this);
    }
    
    // writes to the buffer of this specific thread
    public void writeToBuffer(String msg)
    {
        msg = em.encrypt(msg);
        try
        {
           dataout.writeBytes(msg + "\n"); 
        }
        catch (IOException e)
        {
            e.printStackTrace();
            go = false;
        }
        
    }
    
    // retrieve the username associated with the thread in order to send it out to all other clients
    public String getUsername()
    {
        return name;
    }

}
