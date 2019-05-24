/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package chatroom.gui;

import chatroom.database.DBAccounts;
import client.Client;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;

/**
 *
 * @author Cole
 */
public class LoginGUI implements IGUI
{

    private Pane root;
    private TextField username;
    private TextField password;
    private Button login;
    private Button regbtn;

    private DBAccounts db;

    private final String TITLE = "Login";

    public LoginGUI()
    {
        username = new TextField();
        password = new TextField();
        login = new Button();
        regbtn = new Button();
        root = new Pane();
    }

    @Override
    public Scene setup()
    {
        int x = 25;
        int y = 80;
        int width = 250;

        username.setText("username");
        username.setLayoutX(x);
        username.setLayoutY(y - 50);
        username.setPrefWidth(width);

        password.setText("password");
        password.setLayoutX(x);
        password.setLayoutY(username.getLayoutY() + 40);
        password.setPrefWidth(width);

        login.setText("Login");
        login.setLayoutX(x + 190);
        login.setLayoutY(y + 30);
        login.setPrefWidth(width - 190);

        regbtn.setText("Reg. Account");
        regbtn.setLayoutX(login.getLayoutX() - 90);
        regbtn.setLayoutY(login.getLayoutY());

        root.getChildren().add(username);
        root.getChildren().add(password);
        root.getChildren().add(login);
        root.getChildren().add(regbtn);

        Stage primaryStage = new Stage();
        Scene scene = new Scene(root, 300, 150);

        return scene;
    }

    @Override
    public String getTitle()
    {
        return TITLE;
    }

    public Button getRegbtn()
    {
        return regbtn;
    }

    public Button getLogin()
    {
        return login;
    }

    public boolean canLogin(Client client)
    {
        boolean result = false;
        String command = "&login-" + username.getText() + "-" + password.getText();
        String str = client.sendMessage(command);

        Alert a = new Alert(AlertType.CONFIRMATION);

        if (str.contains("ERROR:"))
        {
            a.setAlertType(AlertType.ERROR);

        }
        a.setContentText(str);
        a.show();

        if (a.getAlertType() == AlertType.CONFIRMATION)
        {
            client.setUsername(username.getText());
            result = true;
        }
        return result;
    }

    @Override
    public void closeGUI()
    {
        System.exit(0);
    }

}
