   M S B A M L   `   `   `  ����	  WPFUI    WPFUI.CreatePrize   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5        � Title$  Создать приз��5      $	��550��5	      $	��570��5
         MaterialDesignBackground#���   5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5      $��16(�5      $��Regular"�5        MaterialDesignBody#���  5       � WindowStartupLocation$ CenterScreen=�5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��128 �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��90.027 �6   �� 5      $��90.027 �6   �� 5      $��90.027 �6   �� 5      $��90.027 �6   �� 5       $
��Auto �6   .+�5"   
   �� $��	-1,0,29,0q�5#      $��Center=�5$      $
��Bold"�5%       $  MaterialDesignHeadline2TextBlock#��[ 5&        cp_title#���  5'       �� TextAlignment$ Center=�5(      �� 5)   
   -   5        $��txtPlaceNumber��5*      $��1��5+      $	��200��5,      $��176,24,203,0q�5-      $	��Top=�5.        cp_place_number)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5/       � Cursor$ Arrow��50       ! MaterialDesignOutlinedTextBox#��[ 51      �� 53   
   -   5        $��txtPlaceName��54      $��2��55      $	��200��56      $��176,0,203,0q�57      $��Center=�58        cp_place_name# �  59      #��[ 5:      �� 5<   
   -   5        $��txtPrizeAmount��5=      $��3��5>      $	��200��5?      $��176,24,203,0q�5@      $	��Top=�5A        cp_prize_sum# �  5B      #��[ 5C      $��0��5D      �� 5F   
   -   5        $��txtPrizePercentage��5G      $��4��5H      $	��200��5I      $��176,23,203,0q�5J      $	��Top=�5K       	 cp_prize_sum_perc# � 	 5L      #��[ 5M      $��0��5N      �� 5P   
   -   5        $��5��5Q      $��60��5R      $��150,9,177,-69q�5S       
 	cp_create#��� 
 5U      $
 Hand��5V       $  MaterialDesignOutlinedDarkButton#��[ 5W      5X      5Y      