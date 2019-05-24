/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package chatroom.gui;

import javafx.scene.Scene;

/**
 *
 * @author Cole
 */
public interface IGUI
{
    public Scene setup();
    public String getTitle();
    public void closeGUI();
}
