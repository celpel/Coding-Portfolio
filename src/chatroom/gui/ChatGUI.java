/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package chatroom.gui;

import chatroom.encryption.EncryptionManager;
import client.Client;
import java.io.IOException;
import javafx.application.Platform;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.control.Button;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.layout.Pane;

/**
 *
 * @author Cole
 */
public class ChatGUI implements IGUI
{
    
    private Pane root;
    private TextArea displayWindow;
    private TextArea userDWindow;
    private TextField chatBox;
    private Button enterBtn;
    
    private EncryptionManager em;
    private String lastRMessage; // last received message

    private Client client;
    
    private final String TITLE = "Chatroom";
    
    public ChatGUI(Client client)
    {
        this.root = new Pane();
        this.displayWindow = new TextArea();
        this.userDWindow = new TextArea();
        this.chatBox = new TextField();
        this.enterBtn = new Button();
        this.em = new EncryptionManager();
        this.client = client;
    }
    
    @Override
    public Scene setup()
    {
        enterBtn.setText("Send");
        
        displayWindow.setWrapText(true);
        displayWindow.setPrefColumnCount(30);
        displayWindow.setPrefRowCount(12);
        displayWindow.setEditable(false);
        
        userDWindow.setLayoutX(368);
        userDWindow.setPrefWidth(100);
        userDWindow.setPrefRowCount(displayWindow.getPrefRowCount() - 1);
        userDWindow.setEditable(false);
        
        chatBox.setLayoutY(220);
        chatBox.setPrefWidth(365);
        
        enterBtn.setLayoutX(chatBox.getPrefWidth() + 2);
        enterBtn.setLayoutY(chatBox.getLayoutY());
        enterBtn.setPrefWidth(100);
        
        root.getChildren().add(displayWindow);
        root.getChildren().add(userDWindow);
        root.getChildren().add(chatBox);
        root.getChildren().add(enterBtn);
        
        Scene scene = new Scene(root, 470, 250);
        
        Thread t = new Thread(() ->
        {
            while (true)
            {
                try
                {
                    lastRMessage = receiveMessage();
                    lastRMessage = em.decrypt(lastRMessage);
                    
                    if (!lastRMessage.equals(""))
                    {
                        Platform.runLater(() ->
                        {
                            displayWindow.appendText(lastRMessage + "\n");
                        });
                    }
                    
                    Thread.sleep(200);
                }
                catch (Exception e)
                {
                    System.exit(0);
                }
            }
        });
        
        t.start();
        
        return scene;
    }
    
    public void sendMessage()
    {
        String message = chatBox.getText();
        
        if (message.length() > 2000) // check if message is valid
        {
            Alert a = new Alert(AlertType.ERROR);
            a.setContentText("ERROR: Text cannot be over 2000 characters long. Your message was " + message.length() + " characters long.");
            a.show();
        }
        else
        {
            // prepare message to be sent
            String msg = client.getUsername() + ": " + message;
            displayWindow.appendText(msg + "\n");
            message = "&msg-" + msg;
            message = em.encrypt(message);
            
            // send and receive message
            client.sendMessage(message);
        }
        
        chatBox.setText("");
    }

    // THIS is the problem
    public String receiveMessage() throws IOException
    {
        String receivedMessage = client.receiveChatMessage();
        receivedMessage = em.decrypt(receivedMessage);
        return receivedMessage;
    }
    
    public Button getEnterBtn()
    {
        return enterBtn;
    }
    
    @Override
    public String getTitle()
    {
        return TITLE;
    }
    
    @Override
    public void closeGUI()
    {
        System.exit(0);
    }
    
}
