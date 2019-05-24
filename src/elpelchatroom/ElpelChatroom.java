/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package elpelchatroom;

import chatroom.gui.ChatGUI;
import chatroom.gui.ConnectGUI;
import chatroom.gui.GUI;
import chatroom.gui.IGUI;
import chatroom.gui.LoginGUI;
import chatroom.gui.RegNewAcctGUI;
import client.Client;
import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.stage.Stage;

/**
 *
 * @author Cole
 */
public class ElpelChatroom extends Application
{

    /**
     * @param args the command line arguments
     */
    private Stage window;
    private Client client;
    private IGUI gui;

    public static void main(String[] args)
    {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage) throws Exception
    {
        window = primaryStage;
        window.setOnCloseRequest((WindowEvent) ->
        {
            try
            {
                client.disconnect();   
                gui.closeGUI();
            }
            catch(NullPointerException npe)
            {
                // if the client isn't instantiated, just close out the client anyway
            }
            
        });
        changeStage(GUI.CONNECT);
    }

    private void changeStage(GUI g)
    {
        gui = changeScene(g);
        window.setScene(gui.setup());
        window.setTitle(gui.getTitle());
        window.show();
    }

    private IGUI changeScene(GUI g)
    {
        IGUI gui = null;
        switch (g)
        {
            case CONNECT:
                gui = initConnectGUI();
                break;
            case LOGIN:
                gui = initLoginGUI();
                break;
            case REGISTRATION:
                gui = initRNAGUI();
                break;
            case CHATROOM:
                gui = initChatRoomGUI();
                break;
        }

        return gui;
    }

    private IGUI initConnectGUI()
    {
        ConnectGUI cgui = new ConnectGUI();
        
        
        cgui.getConnectBtn().setOnAction((ActionEvent e) ->
        {
            Alert a = new Alert(AlertType.ERROR);
            
            String ip = cgui.getIPText();
            int port = 0;
            
            try
            {
                port = Integer.parseInt(cgui.getPortText());
            }
            catch (NumberFormatException nfe)
            {
                a.setContentText("Invalid port");
                a.show();
            }
            
            client = new Client(ip, port);

            if (client.connect())
            {
                a.setAlertType(AlertType.CONFIRMATION);
                a.setContentText("Connection successful.");
                a.show();
                
                changeStage(GUI.LOGIN);
            }
            else
            {
                a.setContentText("ERROR: Your ip may be invalid or the server may be down.");
                a.show();
            }
        });

        return cgui;
    }

    private IGUI initLoginGUI()
    {
        LoginGUI lgui = new LoginGUI();

        lgui.getRegbtn().setOnAction((ActionEvent) ->
        {
            changeStage(GUI.REGISTRATION);
        });

        lgui.getLogin().setOnAction((ActionEvent) ->
        {
            if (lgui.canLogin(client))
            {
                changeStage(GUI.CHATROOM);
            }
        });

        return lgui;
    }

    private IGUI initRNAGUI()
    {
        RegNewAcctGUI rnagui = new RegNewAcctGUI();

        rnagui.getConfirmBtn().setOnAction((ActionEvent) ->
        {
            if (rnagui.verifyFields(client))
            {
                changeStage(GUI.CHATROOM);
            }
        });

        return rnagui;
    }

    private IGUI initChatRoomGUI()
    {
        ChatGUI chgui = new ChatGUI(client);

        chgui.getEnterBtn().setOnAction((ActionEvent) ->
        {
            chgui.sendMessage();
        });

        return chgui;
    }

}
