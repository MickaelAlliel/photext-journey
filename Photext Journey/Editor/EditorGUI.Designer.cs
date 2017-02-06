namespace Photext_Journey.Editor
{
    partial class EditorGUI
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_hide = new System.Windows.Forms.Button();
            this.groupBox_tiles = new System.Windows.Forms.GroupBox();
            this.radioButton_Store = new System.Windows.Forms.RadioButton();
            this.radioButton_Chest_Open = new System.Windows.Forms.RadioButton();
            this.radioButton_Chest = new System.Windows.Forms.RadioButton();
            this.radioButton_Fence_Vertical = new System.Windows.Forms.RadioButton();
            this.radioButton_Fence_Horizontal = new System.Windows.Forms.RadioButton();
            this.radioButton_warp = new System.Windows.Forms.RadioButton();
            this.radioButton_highGrass = new System.Windows.Forms.RadioButton();
            this.radioButton_stoneBricks = new System.Windows.Forms.RadioButton();
            this.radioButton_yellowStone = new System.Windows.Forms.RadioButton();
            this.radioButton_plank = new System.Windows.Forms.RadioButton();
            this.radioButton_bush = new System.Windows.Forms.RadioButton();
            this.radioButton_wood = new System.Windows.Forms.RadioButton();
            this.radioButton_water = new System.Windows.Forms.RadioButton();
            this.radioButton_stone = new System.Windows.Forms.RadioButton();
            this.radioButton_sky = new System.Windows.Forms.RadioButton();
            this.radioButton_sand = new System.Windows.Forms.RadioButton();
            this.radioButton_rock = new System.Windows.Forms.RadioButton();
            this.radioButton_grassTile = new System.Windows.Forms.RadioButton();
            this.radioButton_grass = new System.Windows.Forms.RadioButton();
            this.radioButton_dirt = new System.Windows.Forms.RadioButton();
            this.radioButton_blank = new System.Windows.Forms.RadioButton();
            this.button_layer1 = new System.Windows.Forms.Button();
            this.button_layer2 = new System.Windows.Forms.Button();
            this.textBox_currentLayer = new System.Windows.Forms.TextBox();
            this.label_layer = new System.Windows.Forms.Label();
            this.label_currentLayer = new System.Windows.Forms.Label();
            this.label_width = new System.Windows.Forms.Label();
            this.label_height = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.label_helpLeft = new System.Windows.Forms.Label();
            this.label_helpRight = new System.Windows.Forms.Label();
            this.button_fillScreen = new System.Windows.Forms.Button();
            this.saveFileDialog_level = new System.Windows.Forms.SaveFileDialog();
            this.button_load = new System.Windows.Forms.Button();
            this.openFileDialog_level = new System.Windows.Forms.OpenFileDialog();
            this.button_layer3 = new System.Windows.Forms.Button();
            this.groupBox_entities = new System.Windows.Forms.GroupBox();
            this.radioButton_Goblin = new System.Windows.Forms.RadioButton();
            this.radioButton_Bird = new System.Windows.Forms.RadioButton();
            this.radioButton_necromancer = new System.Windows.Forms.RadioButton();
            this.radioButton_wizard = new System.Windows.Forms.RadioButton();
            this.radioButton_Slime = new System.Windows.Forms.RadioButton();
            this.button_Entities = new System.Windows.Forms.Button();
            this.label_entities = new System.Windows.Forms.Label();
            this.textBox_entities = new System.Windows.Forms.TextBox();
            this.groupBox_tiles.SuspendLayout();
            this.groupBox_entities.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_hide
            // 
            this.button_hide.Location = new System.Drawing.Point(372, 550);
            this.button_hide.Name = "button_hide";
            this.button_hide.Size = new System.Drawing.Size(80, 40);
            this.button_hide.TabIndex = 0;
            this.button_hide.Text = "Hide";
            this.button_hide.UseVisualStyleBackColor = true;
            this.button_hide.Click += new System.EventHandler(this.button_hide_Click);
            // 
            // groupBox_tiles
            // 
            this.groupBox_tiles.Controls.Add(this.radioButton_Store);
            this.groupBox_tiles.Controls.Add(this.radioButton_Chest_Open);
            this.groupBox_tiles.Controls.Add(this.radioButton_Chest);
            this.groupBox_tiles.Controls.Add(this.radioButton_Fence_Vertical);
            this.groupBox_tiles.Controls.Add(this.radioButton_Fence_Horizontal);
            this.groupBox_tiles.Controls.Add(this.radioButton_warp);
            this.groupBox_tiles.Controls.Add(this.radioButton_highGrass);
            this.groupBox_tiles.Controls.Add(this.radioButton_stoneBricks);
            this.groupBox_tiles.Controls.Add(this.radioButton_yellowStone);
            this.groupBox_tiles.Controls.Add(this.radioButton_plank);
            this.groupBox_tiles.Controls.Add(this.radioButton_bush);
            this.groupBox_tiles.Controls.Add(this.radioButton_wood);
            this.groupBox_tiles.Controls.Add(this.radioButton_water);
            this.groupBox_tiles.Controls.Add(this.radioButton_stone);
            this.groupBox_tiles.Controls.Add(this.radioButton_sky);
            this.groupBox_tiles.Controls.Add(this.radioButton_sand);
            this.groupBox_tiles.Controls.Add(this.radioButton_rock);
            this.groupBox_tiles.Controls.Add(this.radioButton_grassTile);
            this.groupBox_tiles.Controls.Add(this.radioButton_grass);
            this.groupBox_tiles.Controls.Add(this.radioButton_dirt);
            this.groupBox_tiles.Controls.Add(this.radioButton_blank);
            this.groupBox_tiles.Location = new System.Drawing.Point(12, 12);
            this.groupBox_tiles.Name = "groupBox_tiles";
            this.groupBox_tiles.Size = new System.Drawing.Size(440, 171);
            this.groupBox_tiles.TabIndex = 1;
            this.groupBox_tiles.TabStop = false;
            this.groupBox_tiles.Text = "Tiles";
            // 
            // radioButton_Store
            // 
            this.radioButton_Store.AutoSize = true;
            this.radioButton_Store.Location = new System.Drawing.Point(314, 70);
            this.radioButton_Store.Name = "radioButton_Store";
            this.radioButton_Store.Size = new System.Drawing.Size(50, 17);
            this.radioButton_Store.TabIndex = 22;
            this.radioButton_Store.TabStop = true;
            this.radioButton_Store.Text = "Store";
            this.radioButton_Store.UseVisualStyleBackColor = true;
            // 
            // radioButton_Chest_Open
            // 
            this.radioButton_Chest_Open.AutoSize = true;
            this.radioButton_Chest_Open.Location = new System.Drawing.Point(314, 44);
            this.radioButton_Chest_Open.Name = "radioButton_Chest_Open";
            this.radioButton_Chest_Open.Size = new System.Drawing.Size(87, 17);
            this.radioButton_Chest_Open.TabIndex = 21;
            this.radioButton_Chest_Open.TabStop = true;
            this.radioButton_Chest_Open.Text = "Chest (Open)";
            this.radioButton_Chest_Open.UseVisualStyleBackColor = true;
            // 
            // radioButton_Chest
            // 
            this.radioButton_Chest.AutoSize = true;
            this.radioButton_Chest.Location = new System.Drawing.Point(314, 19);
            this.radioButton_Chest.Name = "radioButton_Chest";
            this.radioButton_Chest.Size = new System.Drawing.Size(52, 17);
            this.radioButton_Chest.TabIndex = 20;
            this.radioButton_Chest.TabStop = true;
            this.radioButton_Chest.Text = "Chest";
            this.radioButton_Chest.UseVisualStyleBackColor = true;
            // 
            // radioButton_Fence_Vertical
            // 
            this.radioButton_Fence_Vertical.AutoSize = true;
            this.radioButton_Fence_Vertical.Location = new System.Drawing.Point(219, 139);
            this.radioButton_Fence_Vertical.Name = "radioButton_Fence_Vertical";
            this.radioButton_Fence_Vertical.Size = new System.Drawing.Size(71, 17);
            this.radioButton_Fence_Vertical.TabIndex = 19;
            this.radioButton_Fence_Vertical.TabStop = true;
            this.radioButton_Fence_Vertical.Text = "Fence (V)";
            this.radioButton_Fence_Vertical.UseVisualStyleBackColor = true;
            // 
            // radioButton_Fence_Horizontal
            // 
            this.radioButton_Fence_Horizontal.AutoSize = true;
            this.radioButton_Fence_Horizontal.Location = new System.Drawing.Point(219, 116);
            this.radioButton_Fence_Horizontal.Name = "radioButton_Fence_Horizontal";
            this.radioButton_Fence_Horizontal.Size = new System.Drawing.Size(72, 17);
            this.radioButton_Fence_Horizontal.TabIndex = 18;
            this.radioButton_Fence_Horizontal.TabStop = true;
            this.radioButton_Fence_Horizontal.Text = "Fence (H)";
            this.radioButton_Fence_Horizontal.UseVisualStyleBackColor = true;
            // 
            // radioButton_warp
            // 
            this.radioButton_warp.AutoSize = true;
            this.radioButton_warp.Location = new System.Drawing.Point(219, 93);
            this.radioButton_warp.Name = "radioButton_warp";
            this.radioButton_warp.Size = new System.Drawing.Size(51, 17);
            this.radioButton_warp.TabIndex = 17;
            this.radioButton_warp.TabStop = true;
            this.radioButton_warp.Text = "Warp";
            this.radioButton_warp.UseVisualStyleBackColor = true;
            // 
            // radioButton_highGrass
            // 
            this.radioButton_highGrass.AutoSize = true;
            this.radioButton_highGrass.Location = new System.Drawing.Point(35, 116);
            this.radioButton_highGrass.Name = "radioButton_highGrass";
            this.radioButton_highGrass.Size = new System.Drawing.Size(77, 17);
            this.radioButton_highGrass.TabIndex = 16;
            this.radioButton_highGrass.TabStop = true;
            this.radioButton_highGrass.Text = "High Grass";
            this.radioButton_highGrass.UseVisualStyleBackColor = true;
            // 
            // radioButton_stoneBricks
            // 
            this.radioButton_stoneBricks.AutoSize = true;
            this.radioButton_stoneBricks.Location = new System.Drawing.Point(118, 44);
            this.radioButton_stoneBricks.Name = "radioButton_stoneBricks";
            this.radioButton_stoneBricks.Size = new System.Drawing.Size(85, 17);
            this.radioButton_stoneBricks.TabIndex = 15;
            this.radioButton_stoneBricks.TabStop = true;
            this.radioButton_stoneBricks.Text = "Stone Bricks";
            this.radioButton_stoneBricks.UseVisualStyleBackColor = true;
            // 
            // radioButton_yellowStone
            // 
            this.radioButton_yellowStone.AutoSize = true;
            this.radioButton_yellowStone.Location = new System.Drawing.Point(118, 70);
            this.radioButton_yellowStone.Name = "radioButton_yellowStone";
            this.radioButton_yellowStone.Size = new System.Drawing.Size(87, 17);
            this.radioButton_yellowStone.TabIndex = 14;
            this.radioButton_yellowStone.TabStop = true;
            this.radioButton_yellowStone.Text = "Yellow Stone";
            this.radioButton_yellowStone.UseVisualStyleBackColor = true;
            // 
            // radioButton_plank
            // 
            this.radioButton_plank.AutoSize = true;
            this.radioButton_plank.Location = new System.Drawing.Point(118, 93);
            this.radioButton_plank.Name = "radioButton_plank";
            this.radioButton_plank.Size = new System.Drawing.Size(52, 17);
            this.radioButton_plank.TabIndex = 13;
            this.radioButton_plank.TabStop = true;
            this.radioButton_plank.Text = "Plank";
            this.radioButton_plank.UseVisualStyleBackColor = true;
            // 
            // radioButton_bush
            // 
            this.radioButton_bush.AutoSize = true;
            this.radioButton_bush.Location = new System.Drawing.Point(219, 19);
            this.radioButton_bush.Name = "radioButton_bush";
            this.radioButton_bush.Size = new System.Drawing.Size(49, 17);
            this.radioButton_bush.TabIndex = 12;
            this.radioButton_bush.TabStop = true;
            this.radioButton_bush.Text = "Bush";
            this.radioButton_bush.UseVisualStyleBackColor = true;
            // 
            // radioButton_wood
            // 
            this.radioButton_wood.AutoSize = true;
            this.radioButton_wood.Location = new System.Drawing.Point(118, 116);
            this.radioButton_wood.Name = "radioButton_wood";
            this.radioButton_wood.Size = new System.Drawing.Size(54, 17);
            this.radioButton_wood.TabIndex = 11;
            this.radioButton_wood.TabStop = true;
            this.radioButton_wood.Text = "Wood";
            this.radioButton_wood.UseVisualStyleBackColor = true;
            // 
            // radioButton_water
            // 
            this.radioButton_water.AutoSize = true;
            this.radioButton_water.Location = new System.Drawing.Point(118, 139);
            this.radioButton_water.Name = "radioButton_water";
            this.radioButton_water.Size = new System.Drawing.Size(54, 17);
            this.radioButton_water.TabIndex = 9;
            this.radioButton_water.TabStop = true;
            this.radioButton_water.Text = "Water";
            this.radioButton_water.UseVisualStyleBackColor = true;
            // 
            // radioButton_stone
            // 
            this.radioButton_stone.AutoSize = true;
            this.radioButton_stone.Location = new System.Drawing.Point(35, 139);
            this.radioButton_stone.Name = "radioButton_stone";
            this.radioButton_stone.Size = new System.Drawing.Size(53, 17);
            this.radioButton_stone.TabIndex = 8;
            this.radioButton_stone.TabStop = true;
            this.radioButton_stone.Text = "Stone";
            this.radioButton_stone.UseVisualStyleBackColor = true;
            // 
            // radioButton_sky
            // 
            this.radioButton_sky.AutoSize = true;
            this.radioButton_sky.Location = new System.Drawing.Point(219, 44);
            this.radioButton_sky.Name = "radioButton_sky";
            this.radioButton_sky.Size = new System.Drawing.Size(43, 17);
            this.radioButton_sky.TabIndex = 7;
            this.radioButton_sky.TabStop = true;
            this.radioButton_sky.Text = "Sky";
            this.radioButton_sky.UseVisualStyleBackColor = true;
            // 
            // radioButton_sand
            // 
            this.radioButton_sand.AutoSize = true;
            this.radioButton_sand.Location = new System.Drawing.Point(118, 20);
            this.radioButton_sand.Name = "radioButton_sand";
            this.radioButton_sand.Size = new System.Drawing.Size(50, 17);
            this.radioButton_sand.TabIndex = 6;
            this.radioButton_sand.TabStop = true;
            this.radioButton_sand.Text = "Sand";
            this.radioButton_sand.UseVisualStyleBackColor = true;
            // 
            // radioButton_rock
            // 
            this.radioButton_rock.AutoSize = true;
            this.radioButton_rock.Location = new System.Drawing.Point(219, 70);
            this.radioButton_rock.Name = "radioButton_rock";
            this.radioButton_rock.Size = new System.Drawing.Size(51, 17);
            this.radioButton_rock.TabIndex = 5;
            this.radioButton_rock.TabStop = true;
            this.radioButton_rock.Text = "Rock";
            this.radioButton_rock.UseVisualStyleBackColor = true;
            // 
            // radioButton_grassTile
            // 
            this.radioButton_grassTile.AutoSize = true;
            this.radioButton_grassTile.Location = new System.Drawing.Point(34, 93);
            this.radioButton_grassTile.Name = "radioButton_grassTile";
            this.radioButton_grassTile.Size = new System.Drawing.Size(78, 17);
            this.radioButton_grassTile.TabIndex = 4;
            this.radioButton_grassTile.TabStop = true;
            this.radioButton_grassTile.Text = "Grass (Tile)";
            this.radioButton_grassTile.UseVisualStyleBackColor = true;
            // 
            // radioButton_grass
            // 
            this.radioButton_grass.AutoSize = true;
            this.radioButton_grass.Location = new System.Drawing.Point(34, 70);
            this.radioButton_grass.Name = "radioButton_grass";
            this.radioButton_grass.Size = new System.Drawing.Size(52, 17);
            this.radioButton_grass.TabIndex = 3;
            this.radioButton_grass.TabStop = true;
            this.radioButton_grass.Text = "Grass";
            this.radioButton_grass.UseVisualStyleBackColor = true;
            // 
            // radioButton_dirt
            // 
            this.radioButton_dirt.AutoSize = true;
            this.radioButton_dirt.Location = new System.Drawing.Point(35, 44);
            this.radioButton_dirt.Name = "radioButton_dirt";
            this.radioButton_dirt.Size = new System.Drawing.Size(41, 17);
            this.radioButton_dirt.TabIndex = 1;
            this.radioButton_dirt.TabStop = true;
            this.radioButton_dirt.Text = "Dirt";
            this.radioButton_dirt.UseVisualStyleBackColor = true;
            // 
            // radioButton_blank
            // 
            this.radioButton_blank.AutoSize = true;
            this.radioButton_blank.Location = new System.Drawing.Point(35, 20);
            this.radioButton_blank.Name = "radioButton_blank";
            this.radioButton_blank.Size = new System.Drawing.Size(52, 17);
            this.radioButton_blank.TabIndex = 0;
            this.radioButton_blank.TabStop = true;
            this.radioButton_blank.Text = "Blank";
            this.radioButton_blank.UseVisualStyleBackColor = true;
            // 
            // button_layer1
            // 
            this.button_layer1.Location = new System.Drawing.Point(12, 202);
            this.button_layer1.Name = "button_layer1";
            this.button_layer1.Size = new System.Drawing.Size(80, 40);
            this.button_layer1.TabIndex = 2;
            this.button_layer1.Text = "Layer 1";
            this.button_layer1.UseVisualStyleBackColor = true;
            this.button_layer1.Click += new System.EventHandler(this.button_layer1_Click);
            // 
            // button_layer2
            // 
            this.button_layer2.Location = new System.Drawing.Point(98, 202);
            this.button_layer2.Name = "button_layer2";
            this.button_layer2.Size = new System.Drawing.Size(80, 40);
            this.button_layer2.TabIndex = 3;
            this.button_layer2.Text = "Layer 2";
            this.button_layer2.UseVisualStyleBackColor = true;
            this.button_layer2.Click += new System.EventHandler(this.button_layer2_Click);
            // 
            // textBox_currentLayer
            // 
            this.textBox_currentLayer.Location = new System.Drawing.Point(15, 261);
            this.textBox_currentLayer.Name = "textBox_currentLayer";
            this.textBox_currentLayer.ReadOnly = true;
            this.textBox_currentLayer.Size = new System.Drawing.Size(161, 20);
            this.textBox_currentLayer.TabIndex = 4;
            // 
            // label_layer
            // 
            this.label_layer.AutoSize = true;
            this.label_layer.Location = new System.Drawing.Point(12, 186);
            this.label_layer.Name = "label_layer";
            this.label_layer.Size = new System.Drawing.Size(41, 13);
            this.label_layer.TabIndex = 5;
            this.label_layer.Text = "Layers:";
            // 
            // label_currentLayer
            // 
            this.label_currentLayer.AutoSize = true;
            this.label_currentLayer.Location = new System.Drawing.Point(12, 245);
            this.label_currentLayer.Name = "label_currentLayer";
            this.label_currentLayer.Size = new System.Drawing.Size(73, 13);
            this.label_currentLayer.TabIndex = 6;
            this.label_currentLayer.Text = "Current Layer:";
            // 
            // label_width
            // 
            this.label_width.AutoSize = true;
            this.label_width.Location = new System.Drawing.Point(9, 564);
            this.label_width.Name = "label_width";
            this.label_width.Size = new System.Drawing.Size(53, 13);
            this.label_width.TabIndex = 7;
            this.label_width.Text = "Width: 52";
            // 
            // label_height
            // 
            this.label_height.AutoSize = true;
            this.label_height.Location = new System.Drawing.Point(9, 577);
            this.label_height.Name = "label_height";
            this.label_height.Size = new System.Drawing.Size(56, 13);
            this.label_height.TabIndex = 8;
            this.label_height.Text = "Height: 29";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(200, 550);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(80, 40);
            this.button_save.TabIndex = 9;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label_helpLeft
            // 
            this.label_helpLeft.AutoSize = true;
            this.label_helpLeft.Location = new System.Drawing.Point(9, 516);
            this.label_helpLeft.Name = "label_helpLeft";
            this.label_helpLeft.Size = new System.Drawing.Size(102, 13);
            this.label_helpLeft.TabIndex = 10;
            this.label_helpLeft.Text = "Left Click: Draw Tile";
            // 
            // label_helpRight
            // 
            this.label_helpRight.AutoSize = true;
            this.label_helpRight.Location = new System.Drawing.Point(9, 529);
            this.label_helpRight.Name = "label_helpRight";
            this.label_helpRight.Size = new System.Drawing.Size(111, 13);
            this.label_helpRight.TabIndex = 11;
            this.label_helpRight.Text = "Right Click: Erase Tile";
            // 
            // button_fillScreen
            // 
            this.button_fillScreen.Location = new System.Drawing.Point(372, 202);
            this.button_fillScreen.Name = "button_fillScreen";
            this.button_fillScreen.Size = new System.Drawing.Size(80, 40);
            this.button_fillScreen.TabIndex = 13;
            this.button_fillScreen.Text = "Fill Screen";
            this.button_fillScreen.UseVisualStyleBackColor = true;
            this.button_fillScreen.Click += new System.EventHandler(this.button_fillScreen_Click);
            // 
            // saveFileDialog_level
            // 
            this.saveFileDialog_level.Filter = "Text Files|*.txt";
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(286, 550);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(80, 40);
            this.button_load.TabIndex = 14;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // openFileDialog_level
            // 
            this.openFileDialog_level.Filter = "Text Files|*.txt";
            // 
            // button_layer3
            // 
            this.button_layer3.Location = new System.Drawing.Point(184, 202);
            this.button_layer3.Name = "button_layer3";
            this.button_layer3.Size = new System.Drawing.Size(80, 40);
            this.button_layer3.TabIndex = 15;
            this.button_layer3.Text = "Layer 3";
            this.button_layer3.UseVisualStyleBackColor = true;
            this.button_layer3.Click += new System.EventHandler(this.button_layer3_Click);
            // 
            // groupBox_entities
            // 
            this.groupBox_entities.Controls.Add(this.radioButton_Goblin);
            this.groupBox_entities.Controls.Add(this.radioButton_Bird);
            this.groupBox_entities.Controls.Add(this.radioButton_necromancer);
            this.groupBox_entities.Controls.Add(this.radioButton_wizard);
            this.groupBox_entities.Controls.Add(this.radioButton_Slime);
            this.groupBox_entities.Location = new System.Drawing.Point(15, 288);
            this.groupBox_entities.Name = "groupBox_entities";
            this.groupBox_entities.Size = new System.Drawing.Size(440, 171);
            this.groupBox_entities.TabIndex = 16;
            this.groupBox_entities.TabStop = false;
            this.groupBox_entities.Text = "Entities";
            // 
            // radioButton_Goblin
            // 
            this.radioButton_Goblin.AutoSize = true;
            this.radioButton_Goblin.Location = new System.Drawing.Point(32, 111);
            this.radioButton_Goblin.Name = "radioButton_Goblin";
            this.radioButton_Goblin.Size = new System.Drawing.Size(55, 17);
            this.radioButton_Goblin.TabIndex = 26;
            this.radioButton_Goblin.TabStop = true;
            this.radioButton_Goblin.Text = "Goblin";
            this.radioButton_Goblin.UseVisualStyleBackColor = true;
            // 
            // radioButton_Bird
            // 
            this.radioButton_Bird.AutoSize = true;
            this.radioButton_Bird.Location = new System.Drawing.Point(32, 88);
            this.radioButton_Bird.Name = "radioButton_Bird";
            this.radioButton_Bird.Size = new System.Drawing.Size(43, 17);
            this.radioButton_Bird.TabIndex = 25;
            this.radioButton_Bird.TabStop = true;
            this.radioButton_Bird.Text = "Bird";
            this.radioButton_Bird.UseVisualStyleBackColor = true;
            // 
            // radioButton_necromancer
            // 
            this.radioButton_necromancer.AutoSize = true;
            this.radioButton_necromancer.Location = new System.Drawing.Point(32, 65);
            this.radioButton_necromancer.Name = "radioButton_necromancer";
            this.radioButton_necromancer.Size = new System.Drawing.Size(89, 17);
            this.radioButton_necromancer.TabIndex = 24;
            this.radioButton_necromancer.TabStop = true;
            this.radioButton_necromancer.Text = "Necromancer";
            this.radioButton_necromancer.UseVisualStyleBackColor = true;
            // 
            // radioButton_wizard
            // 
            this.radioButton_wizard.AutoSize = true;
            this.radioButton_wizard.Location = new System.Drawing.Point(31, 42);
            this.radioButton_wizard.Name = "radioButton_wizard";
            this.radioButton_wizard.Size = new System.Drawing.Size(58, 17);
            this.radioButton_wizard.TabIndex = 23;
            this.radioButton_wizard.TabStop = true;
            this.radioButton_wizard.Text = "Wizard";
            this.radioButton_wizard.UseVisualStyleBackColor = true;
            // 
            // radioButton_Slime
            // 
            this.radioButton_Slime.AutoSize = true;
            this.radioButton_Slime.Location = new System.Drawing.Point(31, 19);
            this.radioButton_Slime.Name = "radioButton_Slime";
            this.radioButton_Slime.Size = new System.Drawing.Size(50, 17);
            this.radioButton_Slime.TabIndex = 22;
            this.radioButton_Slime.TabStop = true;
            this.radioButton_Slime.Text = "Slime";
            this.radioButton_Slime.UseVisualStyleBackColor = true;
            // 
            // button_Entities
            // 
            this.button_Entities.Location = new System.Drawing.Point(270, 202);
            this.button_Entities.Name = "button_Entities";
            this.button_Entities.Size = new System.Drawing.Size(80, 40);
            this.button_Entities.TabIndex = 17;
            this.button_Entities.Text = "Entities Toggle";
            this.button_Entities.UseVisualStyleBackColor = true;
            this.button_Entities.Click += new System.EventHandler(this.button_Entities_Click);
            // 
            // label_entities
            // 
            this.label_entities.AutoSize = true;
            this.label_entities.Location = new System.Drawing.Point(181, 245);
            this.label_entities.Name = "label_entities";
            this.label_entities.Size = new System.Drawing.Size(72, 13);
            this.label_entities.TabIndex = 18;
            this.label_entities.Text = "Tiling Entities:";
            // 
            // textBox_entities
            // 
            this.textBox_entities.Location = new System.Drawing.Point(182, 262);
            this.textBox_entities.Name = "textBox_entities";
            this.textBox_entities.ReadOnly = true;
            this.textBox_entities.Size = new System.Drawing.Size(161, 20);
            this.textBox_entities.TabIndex = 19;
            // 
            // EditorGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(464, 602);
            this.Controls.Add(this.textBox_entities);
            this.Controls.Add(this.label_entities);
            this.Controls.Add(this.button_Entities);
            this.Controls.Add(this.groupBox_entities);
            this.Controls.Add(this.button_layer3);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.button_fillScreen);
            this.Controls.Add(this.label_helpRight);
            this.Controls.Add(this.label_helpLeft);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label_height);
            this.Controls.Add(this.label_width);
            this.Controls.Add(this.label_currentLayer);
            this.Controls.Add(this.label_layer);
            this.Controls.Add(this.textBox_currentLayer);
            this.Controls.Add(this.button_layer2);
            this.Controls.Add(this.button_layer1);
            this.Controls.Add(this.groupBox_tiles);
            this.Controls.Add(this.button_hide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditorGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditorGUI";
            this.groupBox_tiles.ResumeLayout(false);
            this.groupBox_tiles.PerformLayout();
            this.groupBox_entities.ResumeLayout(false);
            this.groupBox_entities.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_hide;
        private System.Windows.Forms.GroupBox groupBox_tiles;
        private System.Windows.Forms.RadioButton radioButton_rock;
        private System.Windows.Forms.RadioButton radioButton_grassTile;
        private System.Windows.Forms.RadioButton radioButton_grass;
        private System.Windows.Forms.RadioButton radioButton_dirt;
        private System.Windows.Forms.RadioButton radioButton_blank;
        private System.Windows.Forms.Button button_layer1;
        private System.Windows.Forms.Button button_layer2;
        private System.Windows.Forms.TextBox textBox_currentLayer;
        private System.Windows.Forms.Label label_layer;
        private System.Windows.Forms.Label label_currentLayer;
        private System.Windows.Forms.RadioButton radioButton_warp;
        private System.Windows.Forms.RadioButton radioButton_highGrass;
        private System.Windows.Forms.RadioButton radioButton_stoneBricks;
        private System.Windows.Forms.RadioButton radioButton_yellowStone;
        private System.Windows.Forms.RadioButton radioButton_plank;
        private System.Windows.Forms.RadioButton radioButton_bush;
        private System.Windows.Forms.RadioButton radioButton_wood;
        private System.Windows.Forms.RadioButton radioButton_water;
        private System.Windows.Forms.RadioButton radioButton_stone;
        private System.Windows.Forms.RadioButton radioButton_sky;
        private System.Windows.Forms.RadioButton radioButton_sand;
        private System.Windows.Forms.Label label_width;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label_helpLeft;
        private System.Windows.Forms.Label label_helpRight;
        private System.Windows.Forms.RadioButton radioButton_Chest_Open;
        private System.Windows.Forms.RadioButton radioButton_Chest;
        private System.Windows.Forms.RadioButton radioButton_Fence_Vertical;
        private System.Windows.Forms.RadioButton radioButton_Fence_Horizontal;
        private System.Windows.Forms.Button button_fillScreen;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_level;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.OpenFileDialog openFileDialog_level;
        private System.Windows.Forms.Button button_layer3;
        private System.Windows.Forms.GroupBox groupBox_entities;
        private System.Windows.Forms.RadioButton radioButton_wizard;
        private System.Windows.Forms.RadioButton radioButton_Slime;
        private System.Windows.Forms.RadioButton radioButton_necromancer;
        private System.Windows.Forms.Button button_Entities;
        private System.Windows.Forms.Label label_entities;
        private System.Windows.Forms.TextBox textBox_entities;
        private System.Windows.Forms.RadioButton radioButton_Goblin;
        private System.Windows.Forms.RadioButton radioButton_Bird;
        private System.Windows.Forms.RadioButton radioButton_Store;
    }
}