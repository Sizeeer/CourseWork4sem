   M S B A M L   `   `   `  ����	  WPFUI    WPFUI.CreateTeam   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5        � Title$#  Создать команду��5      $	��800��5	      $	��740��5
         MaterialDesignBackground#���   5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5      $��16(�5      $��Regular"�5        MaterialDesignBody#���  5       � WindowStartupLocation$ CenterScreen=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��128 �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��2��5       $��
-1,10,23,0q�5!      $	��Top=�5"      $
��Bold"�5#       $  MaterialDesignHeadline2TextBlock#��[ 5$        cteam_title#���  5%       �� TextAlignment$ Center=�5&      �� 5'   
   -   5        $��txtTeamName��5(      $	��255��5)      $��51��5*      $��45,122,394,0q�5+      $	��Top=�5,        cteam_team_name)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5-       � Cursor$ Arrow��5.       ! MaterialDesignOutlinedTextBox#��[ 5/      �� 51   
   -   5        $��cbSelectTeamMember��52      $	��255��53      $��60��54      $��
43,192,0,0q�55      $
��Left=�56      $	��Top=�57      $��Center=�58        cteam_select_member# �  59       " MaterialDesignOutlinedComboBox#��[ 5:      �� 5;   
   $��46,280,392,81q�6    	 cteam_add_member_text#��� 	 6*   �� 5<   
   -   5        $��txtFirstName��5=      $	��206��5>      $��49��5?      $��70,329,418,0q�5@      $	��Top=�5A       
 cteam_member_name# � 
 5B      $ Arrow��5C      $��12(�5D      #��[ 5E       �� TextWrapping$
 Wrap=�5F      �� 5G   
   -   5        $��txtLastName��5H      $	��206��5I      $��49��5J      $��70,393,418,0q�5K      $	��Top=�5L        cteam_member_lastname# �  5M      	 �� AcceptsReturn	 . $ Arrow��5O      
 J� RenderTransformOrigin$
 
0.484,0.82&�5P      #��[ 5Q      $
 Wrap=�5R      �� 5S   
   -   5        $��txtEmail��5T      $	��206��5U      $��49��5V      $��71,464,417,0q�5W      $	��Top=�5X        cteam_member_email# �  5Y      	 . $ Arrow��5[      $
 
0.484,0.82&�5\      #��[ 5]      $
 Wrap=�5^      �� 5`   
   -   5        $��txtCellPhone��5a      $	��206��5b      $��49��5c      $��70,535,417,0q�5d      $	��Top=�5e        cteam_member_phone# �  5f      	 . $ Arrow��5h      $
 
0.484,0.82&�5i      #��[ 5j      $
 Wrap=�5k      �� 5n   
   -   5        $��50��5o      $
��50.4��5p      $��307,193,0,519q�5q      $
��Left=�5r      $
 Hand��5t       $  MaterialDesignOutlinedDarkButton#��[ 5u         cteam_add_member_btn_tooltip � ToolTip# �  5v      .��5w      '  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�6&      Kind$ AccountPlus=�6C   5x      �� 5z   
   -   5        $	��157��5{      $��40��5|      $��93,614,0,108q�5}      $
��Left=�5~        cteam_create_member_btn#���  5�      $
 Hand��5�      #��[ 5�      �� 5�   
   $��420,122,181,613q�5�       $  MaterialDesignHeadline6TextBlock#��[ 5�        cteam_members_title#���  5�      �� 5�   
   -	   5         ��Name$ lstTeamMembers��5�      $	��275��5�      $	��450��5�      $��	419,0,0,0q�5�      $
��Left=�5�      $��Center=�5�        PrimaryHueMidBrush#���  5�      $��2q�5�      �� 5�   
   -
   5        $��1��5�      $��50��5�      $��50��5�      $��9,156,69,556q�5�      $
 Hand��5�      #��[ 5�         cteam_delete_selected_member# �  5�      .��5�        $��Center=�6&   $ Delete=�6A   5�      �� 5�   
   -   5        $	��272��5�      $��60��5�      $��419,621,0,81q�5�      $
��Left=�5�        cteam_create_team#���  5�      $
 Hand��5�      #��[ 5�      5�      5�      