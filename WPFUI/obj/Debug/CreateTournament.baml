   M S B A M L   `   `   `  ����	  WPFUI    WPFUI.CreateTournament   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5        � Title$!  Создать турнир��5      $	��850��5	      $	��650��5
         MaterialDesignBackground#���   5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5      $��16(�5      $��Regular"�5        MaterialDesignBody#���  5       � WindowStartupLocation$ CenterScreen=�5      .��5      � $��0,0,0,0q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��128 �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��90.027 �6   �� 5      $
��Auto �6   .+�5   
   �� $��2��5       $��0,13,0,0q�5!      $	��Top=�5"      $
��Bold"�5#       $  MaterialDesignHeadline2TextBlock#��[ 5$        ct_title#���  5%       �� TextAlignment$ Center=�5&      �� 5(   
   -   5         ��Name$ txtTournamentName��5)      $��1��5*      $	��270��5+      $��48,31,404,0q�5,      $	��Top=�5-        ct_name_tournament)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5.       ! MaterialDesignOutlinedTextBox#��[ 5/      �� 51   
   -   5        $ txtEntryFee��52      $��2��53      $	��180��54      $��49,22,493,0q�55      $	��Top=�56       
 ct_fee# �  57      .  (MaterialDesignThemes.Wpf.TextFieldAssist   
PrefixText$ $��58      	 � Cursor$	 Arrow��59      #��[ 5;      �� 5=   
   -   5        
 ��Name$
 cbSelectTeam��5>      $��2��5?      $	��304��5@      $��72��5A      $��
48,148,0,0q�5B      $
��Left=�5C      $	��Top=�5D      $��Center=�5E        ct_select_team# �  5F       "	 MaterialDesignOutlinedComboBox#��[	 5G      �� 5I   
   -   5        $��2��5J      $��50��5K      $��50��5L      $��359,149,313,191q�5M      $
	 Hand��5O       $
  MaterialDesignOutlinedDarkButton#��[
 5P        ct_create_team � ToolTip# �  5Q      .��5R      '  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�6&      Kind$ Pencil=�6A   5S      �� 5U   
   -   5        $��2��5V      $��50��5W      $��40��5X      $��191,227,481,103q�5Y      $
	 Hand��5[      #��[
 5\        ct_select_all_teams# �  5]      .��5^        $��Center=�6&   $ CheckAll=�6A   5_      �� 5a   
   -   5        $��2��5b      $	��136��5c      $��40��5d      $��49,227,0,103q�5e      $
��Left=�5f        ct_add_team#���  5h      $
	 Hand��5i      #��[
 5j      �� 5l   
   -   5        $��2��5m      $��1��5n      $��50��5o      $��50��5p      $��9,174,69,166q�5q      $
	 Hand��5s      #��[
 5t        ct_create_prize# �  5u      .��5v        $��Center=�6&   $ Pencil=�6A   5w      �� 5z   
   -   5        $��2��5{      $��1��5|      $��50��5}      $��50��5~      $��9,229,69,111q�5      $
	 Hand��5�      #��[
 5�        ct_delete_prize# �  5�      .��5�        $��Center=�6&   $ Delete=�6A   5�      �� 5�   
   $��1��5�      $��2��5�      $��544,15,73,51q�5�       $  MaterialDesignHeadline6TextBlock#��[ 5�        ct_teams_title#���  5�      �� 5�   
   -	   5         ��Name$ lstTournamentTeams��5�      $��1��5�      $��2��5�      $	��178��5�      $	��191��5�      $��
544,42,0,0q�5�      $
��Left=�5�      $	��Top=�5�        PrimaryHueMidBrush#���  5�      $��2q�5�      �� 5�   
   -
   5        $��1��5�      $��2��5�      $��1��5�      $��50��5�      $��50��5�      $��9,41,69,389q�5�      $
	 Hand��5�      #��[
 5�        ct_delete_team# �  5�      .��5�        $��Center=�6&   $ Delete=�6A   5�      �� 5�   
   $��2��5�      $��2��5�      $��544,149,73,217q�5�      #��[ 5�        ct_prizes_title#���  5�      �� 5�   
   -   5        $ 	lstPrizes��5�      $��2��5�      $	��178��5�      $	��137��5�      $��544,175,0,0q�5�      $
��Left=�5�      $	��Top=�5�      #���  5�      $��2q�5�       J� RenderTransformOrigin$ 0.5,0.5&�5�      �� 5�   
   -   5        $��2��5�      $	��288��5�      $��60��5�      $��292,330,0,0q�5�      $
��Left=�5�        ct_create_tournament#���  5�      $
	 Hand��5�      #��[
 5�      5�      5�      