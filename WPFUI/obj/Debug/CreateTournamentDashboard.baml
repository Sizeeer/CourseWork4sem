   M S B A M L   `   `   `  ����	  WPFUI%    WPFUI.CreateTournamentDashboard   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5        � Title$  Дашборд��5      $	��713��5	      $	��570��5
         MaterialDesignBackground#���   5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5      $��16(�5      $��Regular"�5        MaterialDesignBody#���  5       � WindowStartupLocation$ CenterScreen=�5      .��5      � $��Stretch=�6   $��Stretch=�6)    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   o� -   5         o�Name$ mainMenu��5      $��6��5       $��25��5!      $��0,0,0,0q�5"      $	��Top=�5#        MaterialDesignPaper#���  5$      .@�5%      m� -   5         m�Name$ menuRate��5&      $��25��5'       
 m_rate#���  5)      m� 5*      -   5        $ menuLanguage��5+      $��25��5,      $��Right=�5-        m_menu_language#���  5.      50      �� 51   
   $	��713��52      $��0,45,0,0q�53      $��Center=�54      $	��Top=�55      $
��Bold"�56       $  MaterialDesignHeadline2TextBlock#��[ 57        m_title#���  58       �� TextAlignment$ Center=�59      �� 5:   
   -   5        $��cbLoadExistingTournament��5;      $	��304��5<      $��72��5=      $��173,190,0,0q�5>      $
��Left=�5?      $	��Top=�5@      $��Center=�5A        m_select_helper)  #MaterialDesignThemes.Wpf.HintAssist   
HelperText# �  5B      	   HelperTextFontSize$	 16Q�5C       "	 MaterialDesignOutlinedComboBox#��[	 5D      �� 5E   
   -   5        $��60��5F      $��60��5G      $��486,198,167,306q�5H      
 � Cursor$

 Hand��5J       $
  MaterialDesignOutlinedDarkButton#��[
 5K        m_download_tournament � ToolTip# �  5L      .��5M      '  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�6&      Kind$ TrayArrowDown=�6A   5N      �� 5O   
   -   5        $	��258��5P      $��60��5Q      $��0,352,101,152q�5R      $��Right=�5S        m_create_btn#���  5U      #��[
 5V      �� 5W   
   -   5        $	��258��5X      $��60��5Y      $��84,352,0,152q�5Z      $
��Left=�5[        	m_del_btn#���  5]      #��[
 5^      5_      5`      