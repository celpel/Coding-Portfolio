/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package chatroom.gui;

import chatroom.database.DBAccounts;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.layout.Pane;

/**
 *
 * @author Cole
 */
public class ConnectGUI implements IGUI
{

    private Pane root;
    private TextField ip;
    private TextField port;
    private Button connectBtn;
    private DBAccounts db;

    private final String TITLE = "Connect";

    public ConnectGUI()
    {
        ip = new TextField();
        port = new TextField();
        connectBtn = new Button();
        root = new Pane();
        db = new DBAccounts();
    }

    @Override
    public Scene setup()
    {
        int x = 29;
        int y = 25;
        ip.setLayoutX(x);
        ip.setLayoutY(y);
        ip.setPrefWidth(100);
        ip.setText("ip");

        port.setLayoutX(ip.getLayoutX() + ip.getPrefWidth() + 2);
        port.setLayoutY(ip.getLayoutY());
        port.setPrefWidth(ip.getPrefWidth() / 2);
        port.setText("port");

        connectBtn.setText("Connect");
        connectBtn.setLayoutX(x + 90);
        connectBtn.setLayoutY(y + 30);

        root.getChildren().add(ip);
        root.getChildren().add(port);
        root.getChildren().add(connectBtn);
        Scene scene = new Scene(root, 200, 100);

        return scene;
    }

    public String getIPText()
    {
        return ip.getText();
    }

    public String getPortText()
    {
        return port.getText();
    }

    public Button getConnectBtn()
    {
        return connectBtn;
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
