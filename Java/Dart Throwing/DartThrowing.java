/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dartthrowing;

import java.util.concurrent.ThreadLocalRandom;
import javafx.application.Application;
import javafx.event.EventHandler;
import javafx.scene.Scene;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;
import javafx.scene.canvas.Canvas;
import javafx.scene.canvas.GraphicsContext;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.input.MouseEvent;
import javafx.scene.paint.Color;

/**
 *
 * @author Cole
 */
public class DartThrowing extends Application
{

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args)
    {
        launch(args);
    }

    @Override
    public void start(Stage primaryStage)
    {
        int xpos = 25;
        int ypos = xpos;

        Pane root = new Pane();
        Scene scene = new Scene(root, 300, 370);

        Canvas c = new Canvas(500, 500);
        CreateSquareCircle(xpos, ypos, c);

        Button btn = new Button();
        btn.setText("Begin Throwing");
        btn.setLayoutX(xpos);
        btn.setLayoutY(ypos + 251);

        TextField tfield = new TextField();
        tfield.setLayoutX(xpos * 5);
        tfield.setLayoutY(btn.getLayoutY());
        tfield.setText("Enter number of darts.");

        btn.setOnMouseClicked(new EventHandler<MouseEvent>()
        {
            @Override
            public void handle(MouseEvent event)
            {
                c.getGraphicsContext2D().clearRect(0, 0, c.getWidth(), c.getHeight()); // clear canvas
                CreateSquareCircle(xpos, ypos, c); // redraw it
                try
                {
                    double t = Double.parseDouble(tfield.getText());
                    double circle = 0;
                    double square = 0;
                    
                    if (t < 0)
                    {
                        throw new NumberFormatException();
                    }

                    for (int i = 0; i < t; i++)
                    {
                        int x = ThreadLocalRandom.current().nextInt(25, 276); // x, y coordinate limits of the square
                        int y = ThreadLocalRandom.current().nextInt(25, 276);
                        
                        if(IsInCircle(x, y))
                        {
                            circle++;
                        }
                        else
                        {
                            square++;
                        }
                        
                        GraphicsContext g = c.getGraphicsContext2D();
                        g.setFill(Color.GREEN);
                        g.fillRect(x - 3, y - 3, 7, 7); // forces the center of the square to be on the point where the dart landed
                    }
                    
                    Alert alert = new Alert(AlertType.INFORMATION);
                    alert.setContentText("Pi: " + circle/square + "");
                    alert.show();

                } catch (NumberFormatException e)
                {

                    Alert a = new Alert(AlertType.ERROR);
                    a.setContentText("Invalid entry. Enter valid number in text box.");
                    a.show();
                    tfield.clear();
                }
            }
        });
        
        root.getChildren().add(c);
        root.getChildren().add(btn);
        root.getChildren().add(tfield);
        primaryStage.setResizable(false);
        primaryStage.setTitle("Darts");
        primaryStage.setScene(scene);
        primaryStage.show();
    }

    public void CreateSquareCircle(int xpos, int ypos, Canvas c)
    {
        GraphicsContext gc = c.getGraphicsContext2D();
        GraphicsContext gc2 = c.getGraphicsContext2D();
        gc.setFill(Color.BLUE);
        gc.fillRect(xpos, ypos, 250, 250);
        gc2.setFill(Color.RED);
        gc2.fillOval(xpos, ypos, 250, 250);
    }
    
    public boolean IsInCircle(int x, int y)
    {
        double x1 = (x - 150)*(x - 150); // center is at 150, 150
        double y1 = (y - 150)*(y - 150);
        double distance = Math.sqrt(x1 + y1);
        
        if(distance <= 125) // radius is 125
        {
            return true;
        }
        else
        {
            return false;
        }
    }
        
}
