// Задание 1: Разработать форму экранной иерархией объектов, содержащую все перечисленные компоненты и работающую с несколькими менеджерами компоновки.

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Lab17 {

    JPanel panel;

    Lab17() {
        panel = new JPanel();
        panel.setBorder(BorderFactory.createEmptyBorder(0, 30, 10, 30));

        JButton button;
        JRadioButton radioButton;
        JTextArea ta = new JTextArea();

        panel.setLayout(new GridBagLayout());
        GridBagConstraints c = new GridBagConstraints();
        c.fill = GridBagConstraints.HORIZONTAL;

        radioButton = new JRadioButton("Radio button");
        c.weightx = 0.5;
        c.fill = GridBagConstraints.HORIZONTAL;
        c.gridx = 0;
        c.gridy = 0;
        panel.add(radioButton, c);

        JTextField tf = new JTextField("infaSotka");
        c.fill = GridBagConstraints.HORIZONTAL;
        c.weightx = 0.8;
        c.gridx = 1;
        c.gridy = 0;
        panel.add(tf, c);

        button = new JButton("Button 3");
        button.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                ta.setText(ta.getText() + "\n" + tf.getText());
            }
        });
        c.fill = GridBagConstraints.HORIZONTAL;
        c.weightx = 0.5;
        c.gridx = 2;
        c.gridy = 0;
        panel.add(button, c);
        
        ta.setText("Sushko Аlexey \n I am tired \n Your text: ");
        c.fill = GridBagConstraints.HORIZONTAL;
        c.gridwidth = 3;
        c.gridx = 0;
        c.gridy = 1;
        panel.add(ta, c);

        Scrollbar sc = new Scrollbar();
        sc.setOrientation(0);
        c.fill = GridBagConstraints.HORIZONTAL;
        c.weightx = 0.5;
        c.gridwidth = 3;
        c.gridx = 0;
        c.gridy = 3;
        panel.add(sc, c);

        JLabel label = new JLabel("How are you?");
        c.gridx = 0;
        c.gridy = 4;
        c.fill = GridBagConstraints.HORIZONTAL;
        panel.add(label, c);

        JComboBox combo = new JComboBox<>(new Color[]{Color.BLACK, Color.CYAN, Color.RED, Color.GREEN, Color.MAGENTA});
        combo.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                label.setForeground((Color) combo.getSelectedItem());
            }
        });
        
        c.fill = GridBagConstraints.HORIZONTAL;
        c.weightx = 0.5;
        c.gridy = 5;
        c.gridx = 0;
        panel.add(combo, c);

        JList<String> list = new JList<>(new String[]{"Great", "Norm", "Not bad", "Poorly", "Terrible"});
        c.fill = GridBagConstraints.HORIZONTAL;
        c.gridx = 1;
        c.gridy = 4;
        c.gridwidth = -1;
        panel.add(list, c);

        JMenu menu = new JMenu("A marks for my work");
        JMenuItem item1 = new JMenuItem("10");
        JMenuItem item2 = new JMenuItem("Ten");
        JMenuItem item3 = new JMenuItem("X");
        JMenuBar bar = new JMenuBar();
        menu.add(item1);
        menu.add(item2);
        menu.add(item3);
        bar.add(menu);
        c.fill = GridBagConstraints.HORIZONTAL;
        c.gridy = 4;
        c.gridx = 2;
        panel.add(bar, c);
        
        JFrame frame = new JFrame("Some elements");
        frame.add(panel);
        frame.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        frame.setLocation(500, 500);
        frame.setSize(400, 300);
        frame.setVisible(true);
    }

    public static void main(String[] args) {
        new Lab17();
    }
}
