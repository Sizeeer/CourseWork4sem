   M S B A M L   `   `   `  ����	  WPFUI    WPFUI.TournamentViewer   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5        � Title$#  Ведение турнира��5      $	��700��5	      $	��600��5
         MaterialDesignBackground#���   5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5      $��16(�5      $��Regular"�5        MaterialDesignBody#���  5       � WindowStartupLocation$ CenterScreen=�5       � DataContext 5      ��  �� RelativeSource ��  �� Mode$
 Self=�.��5      �  � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ lbTournamentName��5      $��2��5      $��40��5      $��1,26,-126,0q�5       $	��Top=�5!      $
��Bold"�5"       $  MaterialDesignHeadline4TextBlock#��[ 5#      $��Название��5$      	 �� TextAlignment$	 Center=�5%      �� 5&   
   $��50��5'      $��30��5(      $��	35,87,0,0q�5)      $
��Left=�5*      $	��Top=�5+      .��5,      �� $��
Раунд��5-      $��Medium"�5.      ���#fff5/      50      �� 52   
   -   5        
 ��Name$
 cbRounds��53      $	��200��54      $��54��55      $��
26,105,0,0q�56      $
��Left=�57      $	��Top=�58      $��Center=�59        v_round)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5:       �� SelectedIndex$ 0��5;       " MaterialDesignOutlinedComboBox#��[ 5=      �� 5>   
   -   5        $��ckbUnplayedOnly��5?      $	��202��5@      $��25��5A      $��
24,168,0,0q�5B      $
��Left=�5C      $	��Top=�5D        v_checkbox_text#���  5F      $��Medium"�5G       d� 	IsChecked$
 TrueY�5H      �� 5J   
   -   5        $��
lstMatchup��5K      $	��261��5L      $��
26,212,4,0q�5M      $	��Top=�5N        PrimaryHueMidBrush#���  5O      $��2q�5P      5Q      �� 5R   
   -   5        $��lbteamOneName��5S      $��1��5T      $	��179��5U      $��41,214,0,287q�5V      $
��Left=�5W        v_team_1#���  5X      �� 5Y   
   -   5         ��Name$ txtTeamOneScore��5Z      $��1��5[      $	��205��5\      $��50��5]      $��
42,247,0,0q�5^      $
��Left=�5_      $	��Top=�5`       	 v_score# � 	 5a       � Cursor$ Arrow��5b      {�.   !
 MaterialDesignOutlinedTextBox#��[
 5e      �� 5g   
   -   5        $��lbteamTwoName��5h      $��1��5i      $	��179��5j      $��39,307,0,194q�5k      $
��Left=�5l        v_team_2#���  5m      �� 5n   
   -   5        $ txtTeamTwoScore��5o      $��1��5p      $	��205��5q      $��50��5r      $��42,342,25,0q�5s      $	��Top=�5t      # � 	 5u      {�.  #��[
 5x      �� 5z   
   -	   5        $��btnScore��5{      $��1��5|      $	��160��5}      $��60��5~      $��63,413,0,52q�5      $
��Left=�5�        v_accept#���  5�      $
 Hand��5�      {�.   $  MaterialDesignOutlinedDarkButton#��[ 5�      )  #MaterialDesignThemes.Wpf.DialogHost  5�   
   -
   5        $��sleepDialog��5�      $��2��5�      $��0,0,-128,-59q�5�         CloseOnClickAway .    DialogContent 5�      �� 5�      $��32q�6   .+�5�      �� $	��Top=�5�      $
��Bold"�5�      #��[ 5�        v_dialog_title#���  5�      $	 Center=�5�      �� 5�      $��	0,16,0,16q�5�      $	��Top=�5�      $
��Bold"�5�       $  MaterialDesignHeadline6TextBlock#��[ 5�      $	 Center=�5�      ��5�      �� *MatchupModalTeams+5�      �� 5�      -   5        $��tbTime��5�      $��	0,16,0,16q�5�      $	��Top=�5�      $
��Bold"�5�      #��[ 5�      $	 Center=�5�      ��5�      ��  �� Path$ StringCountdown� �� UpdateSourceTrigger$ PropertyChanged=�5�      �� 5�      $��Center=�6!   $��Center=�6>   .+�5�      �� -   5        $	��170��5�      $��40��5�      $��5q�5�        v_start#���  5�      $
 Hand��5�      #��[ 5�      �� 5�      -   5        $	��170��5�      $��40��5�      $��5q�5�        v_reset#���  5�      $
 Hand��5�      #��[ 5�      �� 5�      -   5        $	��170��5�      $��40��5�      $��5q�5�        v_pause#���  5�      $
 Hand��5�      #��[ 5�      �� 5�      -   5        $	��170��5�      $��40��5�      $��5q�5�        	v_release#���  5�      $
 Hand��5�      #��[ 5�      5�      5�      5�      5�      5�      