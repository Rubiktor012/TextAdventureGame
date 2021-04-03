Public Class Form1
    Dim HP As Integer
    Dim HPE As Integer = 30
    Dim Apples As Integer
    Dim Gold As Integer
    Dim IsInBattle As Boolean
    Dim Weapon As Integer
    Dim Damage As Integer
    Dim EnemyType As Integer
    Dim EnemyName As String
    Dim Level As Integer
    Dim XP As Integer
    Dim LvlUp As Integer
    Dim TotalDamage As Integer
    Dim MaxHP As Integer
    Dim MaxHPE As Integer
    Dim EnemyDamage As Integer
    Dim GoldAdded As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "/help" Then
            ListBox1.Items.Add("/help - lists all commands")
            ListBox1.Items.Add("/fight - triggers a fight with a monster")
            ListBox1.Items.Add("/apple - uses an apple to heal 20 HP (can be used both in and out of a battle)")
            ListBox1.Items.Add("/stats - displays player stats and inventory")
            ListBox1.Items.Add("/shop - views the shop")
        ElseIf TextBox1.Text = "/fight" Then
            If HPE < 1 Then
                HPE = MaxHPE
            End If
            IsInBattle = True
            ListBox1.Items.Add(TextBox2.Text + " Attacked for " + TotalDamage.ToString + " Damage!")
            HPE -= TotalDamage
            ListBox1.Items.Add("Enemy Golem has " + HPE.ToString + "/" + MaxHPE.ToString + " HP Left")
            If HPE < 1 Then
                ListBox1.Items.Add("The Enemy Golem burst into pebbles.")
                ListBox1.Items.Add(TextBox2.Text + " won the battle!")
                GoldAdded = Level * 23 + 69 - 23
                ListBox1.Items.Add("You Won " + GoldAdded.ToString + " Gold and 1 Apple!")
                XP += 13
                If XP > LvlUp - 1 Then
                    XP -= LvlUp
                    Level += 1
                    LvlUp = Level * 50
                    ListBox1.Items.Add("+ XP (" + XP.ToString + "/" + LvlUp.ToString + ")")
                    ListBox1.Items.Add("You are now Level " + Level.ToString + "!")
                    TotalDamage = Damage + Level - 1
                    MaxHP = Level * 3 - 3 + 50
                Else
                    ListBox1.Items.Add("+13 XP (" + XP.ToString + "/" + LvlUp.ToString + ")")
                End If

                Gold += GoldAdded
                Apples += 1
                My.Settings.Apples = Apples
                My.Settings.Gold = Gold
                My.Settings.HP = HP
                IsInBattle = False
                MaxHPE = Level * 2 - 2 + 30
                EnemyDamage = Level + 2
            Else
                ListBox1.Items.Add("Enemy Golem Attacked for " + EnemyDamage.ToString + " Damage!")
                HP -= EnemyDamage
                ListBox1.Items.Add(TextBox2.Text + " has " + HP.ToString + "/" + MaxHP.ToString + " HP Left")
                If HP < 1 Then
                    Gold /= 5
                    ListBox1.Items.Add(TextBox2.Text + " got hurt and collapsed.")
                    ListBox1.Items.Add(TextBox2.Text + " lost the battle...")
                    ListBox1.Items.Add("You lost " + Gold.ToString + " Gold.")
                    ListBox1.Items.Add("Restart the game to play again!")
                    Gold *= 4
                    My.Settings.HP = MaxHP
                    My.Settings.Gold = Gold
                    Button1.Enabled = False
                End If
            End If
        ElseIf TextBox1.Text = "/apple" Then
            If Apples > 0 Then
                ListBox1.Items.Add(TextBox2.Text + " used an apple!")
                ListBox1.Items.Add("Healed for 20 HP!")
                HP += 20
                If HP > MaxHP Then
                    HP = MaxHP
                End If
                ListBox1.Items.Add("Your current HP is " + HP.ToString + "/" + MaxHP.ToString)
                Apples -= 1
                ListBox1.Items.Add(Apples.ToString + " apples left")
                My.Settings.Apples = Apples
            Else
                ListBox1.Items.Add(TextBox2.Text + " used an a...")
                ListBox1.Items.Add("Oh, true. You're out of apples.")
            End If
            If IsInBattle Then
                ListBox1.Items.Add("Enemy Golem Attacked for " + EnemyDamage.ToString + " Damage!")
                HP -= EnemyDamage
                ListBox1.Items.Add(TextBox2.Text + " has " + HP.ToString + "/" + MaxHP.ToString + " HP Left")
                If HP < 1 Then
                    Gold /= 5
                    ListBox1.Items.Add(TextBox2.Text + " got hurt and collapsed.")
                    ListBox1.Items.Add(TextBox2.Text + " lost the battle...")
                    ListBox1.Items.Add("You lost " + Gold.ToString + " Gold.")
                    ListBox1.Items.Add("Restart the game to play again!")
                    Gold *= 4
                    My.Settings.HP = 50
                    My.Settings.Gold = Gold
                    Button1.Enabled = False
                End If
            End If
        ElseIf TextBox1.Text = "/stats" Then
            ListBox1.Items.Add("------------------------------------------------------------------------------------------------------------------------------------------------")
            ListBox1.Items.Add(TextBox2.Text + "'s Stats:")
            ListBox1.Items.Add("Level " + Level.ToString + " (" + XP.ToString + "/" + LvlUp.ToString + " XP)")
            ListBox1.Items.Add("Gold: " + Gold.ToString)
            ListBox1.Items.Add("HP: " + HP.ToString + "/" + MaxHP.ToString)
            ListBox1.Items.Add("ATK: " + TotalDamage.ToString)
            If Weapon = 1 Then
                ListBox1.Items.Add("Current Weapon: Small Dagger (5 ATK)")
            ElseIf Weapon = 2 Then
                ListBox1.Items.Add("Current Weapon: Apprentice Sword (10 ATK)")
            ElseIf Weapon = 3 Then
                ListBox1.Items.Add("Current Weapon: Iron Blade (25 ATK)")
            ElseIf Weapon = 4 Then
                ListBox1.Items.Add("Current Weapon: Knight's Edge (40 ATK)")
            ElseIf Weapon = 5 Then
                ListBox1.Items.Add("Current Weapon: The Memer's Sword (69 ATK)")
            ElseIf Weapon = 6 Then
                ListBox1.Items.Add("Current Weapon: The Rainbow Blade (149 ATK)")
            End If
            ListBox1.Items.Add("Use /equip and the number to equip (/equip1 for Small Dagger, etc.)")
            ListBox1.Items.Add("Inventory:")
            ListBox1.Items.Add("Apple (X" + Apples.ToString + "): Food Item, Restores 20 HP")
            ListBox1.Items.Add("(1) Small Dagger: Weapon, 5 ATK")
            If My.Settings.HasItem2 = True Then
                ListBox1.Items.Add("(2) Apprentice Sword: Weapon, 10 ATK")
            End If
            If My.Settings.HasItem3 = True Then
                ListBox1.Items.Add("(3) Iron Blade: Weapon, 25 ATK")
            End If
            If My.Settings.HasItem4 = True Then
                ListBox1.Items.Add("(4) Knight's Edge: Weapon, 40 ATK")
            End If
            If My.Settings.HasItem5 = True Then
                ListBox1.Items.Add("(5) The Memer's Sword: Weapon, 69 ATK")
            End If
            If My.Settings.HasItem6 = True Then
                ListBox1.Items.Add("(6) The Rainbow Blade: Weapon, 149 ATK")
            End If
            ListBox1.Items.Add("------------------------------------------------------------------------------------------------------------------------------------------------")
        ElseIf TextBox1.Text = "/shop" Then
            ListBox1.Items.Add("------------------------------------------------------------------------------------------------------------------------------------------------")
            ListBox1.Items.Add("Shop:")
            ListBox1.Items.Add("(You have " + Gold.ToString + " Gold)")
            ListBox1.Items.Add("Use /buy and the number to buy (/buy1 for apples, etc.)")
            ListBox1.Items.Add("(1) Apple: 15 Gold")
            ListBox1.Items.Add("(2) Apprentice Sword: 600 Gold")
            ListBox1.Items.Add("(3) Iron Blade: 1500 Gold")
            ListBox1.Items.Add("(4) Knight's Edge: 2300 Gold")
            ListBox1.Items.Add("(5) The Memer's Sword: 3069 Gold")
            ListBox1.Items.Add("(6) The Rainbow Blade: 9999 Gold")
            ListBox1.Items.Add("------------------------------------------------------------------------------------------------------------------------------------------------")
        ElseIf TextBox1.Text = "/buy1" Then
            If Gold > 14 Then
                ListBox1.Items.Add("You bought an Apple from the Shop!")
                Apples += 1
                ListBox1.Items.Add("You now have " + Apples.ToString + " Apples.")
                Gold -= 15
                ListBox1.Items.Add("Your current Gold is " + Gold.ToString)
                My.Settings.Apples = Apples
                My.Settings.Gold = Gold
            Else
                ListBox1.Items.Add("You can't afford this, you only have " + Gold.ToString + " Gold!")
            End If
        ElseIf TextBox1.Text = "/buy2" Then
            If Gold > 599 Then
                ListBox1.Items.Add("You bought an Apprentice Sword from the Shop!")
                Gold -= 600
                ListBox1.Items.Add("Your current Gold is " + Gold.ToString)
                My.Settings.HasItem2 = True
            Else
                ListBox1.Items.Add("You can't afford this, you only have " + Gold.ToString + " Gold!")
            End If
        ElseIf TextBox1.Text = "/buy3" Then
            If Gold > 1499 Then
                ListBox1.Items.Add("You bought an Iron Blade from the Shop!")
                Gold -= 1500
                ListBox1.Items.Add("Your current Gold is " + Gold.ToString)
                My.Settings.HasItem3 = True
            Else
                ListBox1.Items.Add("You can't afford this, you only have " + Gold.ToString + " Gold!")
            End If
        ElseIf TextBox1.Text = "/buy4" Then
            If Gold > 2299 Then
                ListBox1.Items.Add("You bought a Knight's Edge Sword from the Shop!")
                Gold -= 2300
                ListBox1.Items.Add("Your current Gold is " + Gold.ToString)
                My.Settings.HasItem4 = True
            Else
                ListBox1.Items.Add("You can't afford this, you only have " + Gold.ToString + " Gold!")
            End If
        ElseIf TextBox1.Text = "/buy5" Then
            If Gold > 3068 Then
                ListBox1.Items.Add("You bought The Memer's Sword from the Shop!")
                Gold -= 3069
                ListBox1.Items.Add("Your current Gold is " + Gold.ToString)
                My.Settings.HasItem5 = True
            Else
                ListBox1.Items.Add("You can't afford this, you only have " + Gold.ToString + " Gold!")
            End If
        ElseIf TextBox1.Text = "/buy6" Then
            If Gold > 1998 Then
                ListBox1.Items.Add("You bought an The Rainbow Blade from the Shop!")
                Gold -= 1999
                ListBox1.Items.Add("Your current Gold is " + Gold.ToString)
                My.Settings.HasItem6 = True
            Else
                ListBox1.Items.Add("You can't afford this, you only have " + Gold.ToString + " Gold!")
            End If
        ElseIf TextBox1.Text = "/equip1" Then
            If Weapon = 1 Then
                ListBox1.Items.Add("You already have that item equipped!")
            Else
                Weapon = 1
                My.Settings.Weapon = 1
                ListBox1.Items.Add("You equipped Small Dagger!")
                Damage = 5
                My.Settings.Damage = 5
                TotalDamage = Damage + Level - 1
            End If
        ElseIf TextBox1.Text = "/equip2" Then
            If Weapon = 2 Then
                ListBox1.Items.Add("You already have that item equipped!")
            ElseIf My.Settings.HasItem2 = False Then
                ListBox1.Items.Add("You don't own that item!")
            Else
                Weapon = 2
                My.Settings.Weapon = 2
                ListBox1.Items.Add("You equipped Apprentice Sword!")
                Damage = 10
                My.Settings.Damage = 10
                TotalDamage = Damage + Level - 1
            End If
        ElseIf TextBox1.Text = "/equip3" Then
            If Weapon = 3 Then
                ListBox1.Items.Add("You already have that item equipped!")
            ElseIf My.Settings.HasItem2 = False Then
                ListBox1.Items.Add("You don't own that item!")
            Else
                Weapon = 3
                My.Settings.Weapon = 3
                ListBox1.Items.Add("You equipped Iron Blade!")
                Damage = 25
                My.Settings.Damage = 25
                TotalDamage = Damage + Level - 1
            End If
        ElseIf TextBox1.Text = "/equip4" Then
            If Weapon = 4 Then
                ListBox1.Items.Add("You already have that item equipped!")
            ElseIf My.Settings.HasItem2 = False Then
                ListBox1.Items.Add("You don't own that item!")
            Else
                Weapon = 4
                My.Settings.Weapon = 4
                ListBox1.Items.Add("You equipped Knight's Edge!")
                Damage = 40
                My.Settings.Damage = 40
                TotalDamage = Damage + Level - 1
            End If
        ElseIf TextBox1.Text = "/equip5" Then
            If Weapon = 5 Then
                ListBox1.Items.Add("You already have that item equipped!")
            ElseIf My.Settings.HasItem2 = False Then
                ListBox1.Items.Add("You don't own that item!")
            Else
                Weapon = 5
                My.Settings.Weapon = 5
                ListBox1.Items.Add("You equipped The Memer's Sword!")
                Damage = 69
                My.Settings.Damage = 69
                TotalDamage = Damage + Level - 1
            End If
        ElseIf TextBox1.Text = "/equip6" Then
            If Weapon = 6 Then
                ListBox1.Items.Add("You already have that item equipped!")
            ElseIf My.Settings.HasItem2 = False Then
                ListBox1.Items.Add("You don't own that item!")
            Else
                Weapon = 6
                My.Settings.Weapon = 6
                ListBox1.Items.Add("You equipped The Rainbow Blade!")
                Damage = 199
                My.Settings.Damage = 199
                TotalDamage = Damage + Level - 1
            End If
        Else
            ListBox1.Items.Add(TextBox2.Text + ": " + TextBox1.Text)
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        My.Settings.Username = TextBox2.Text
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = My.Settings.Username
        HP = My.Settings.HP
        Gold = My.Settings.Gold
        Apples = My.Settings.Apples
        Weapon = My.Settings.Weapon
        Damage = My.Settings.Damage
        Level = My.Settings.Level
        XP = My.Settings.XP
        TotalDamage = Damage + Level - 1
        LvlUp = Level * 50
        MaxHP = Level * 3 - 3 + 50
        MaxHPE = Level * 2 - 2 + 30
        EnemyDamage = Level + 2
    End Sub

    Private Sub ResetSaveDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetSaveDataToolStripMenuItem.Click
        Dim Confirmation As Integer
        MsgBox("Are You Sure?", MsgBoxStyle.OkCancel + MsgBoxStyle.Exclamation, "Reset Save Data")
        If Confirmation = 0 Then
            My.Settings.Username = "Player"
            My.Settings.Gold = 420
            My.Settings.HP = 50
            My.Settings.Apples = 3
            My.Settings.HasItem2 = False
            My.Settings.HasItem3 = False
            My.Settings.HasItem4 = False
            My.Settings.HasItem5 = False
            My.Settings.HasItem6 = False
            My.Settings.Weapon = 1
            My.Settings.Damage = 5
            My.Settings.Level = 1
            My.Settings.XP = 0
            MsgBox("Save Data Reset. Reopen the game to continue.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Reset Save Data")
            Close()
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Made by Rubiktor012 on GitHub (https://www.github.com/Rubiktor012/TextAdventureGame).", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "About")
    End Sub
End Class
