using benzo.scripts.globalClass;
using Godot;

namespace benzo.scripts;

public class Builder
{
    public class UserBuilder
    {
        private float Hp, MaxHp, Energy, MaxEnergy;
        private Weapon w1, w2;
        private Vector2 pos;
        private InputManager inputManager;
        public int Me = 0;

        public UserBuilder SetHp(float hp)
        {
            Hp = hp;
            return this;
        }
        
        public UserBuilder SetMaxHp(float maxHp)
        {
            MaxHp = maxHp;
            return this;
        }

        public UserBuilder SetEnergy(float energy)
        {
            Energy = energy;
            return this;
        }

        public UserBuilder SetMaxEnergy(float maxEnergy)
        {
            MaxEnergy = maxEnergy;
            return this;
        }

        public UserBuilder SetPosition(Vector2 position)
        {
            pos = position;
            return this;
        }

        public UserBuilder SetWeapon(int index)
        {
            
            w1 = index switch
            {
                0 => WeaponFactory.CreateIceSword(),
                1 => WeaponFactory.CreateAshsword(),
                2 => WeaponFactory.CreateBow(),
                3 => WeaponFactory.CreateMageStuff()
            };
            return this;
        }
        public UserBuilder SetSecondWeapon(int index)
        {
            w2 = WeaponFactory.CreatePotion();
            return this;
        }
        public UserBuilder SetInputManager(int index)
        {
            inputManager = (index == 0) ? GD.Load<PackedScene>("res://scenes/player/movement/keyboard_input.tscn").Instantiate<KeyBoardInput>() :
                GD.Load<PackedScene>("res://scenes/player/movement/joy_input.tscn").Instantiate<JoyInput>();
            return this;
        }

        public UserBuilder SetHim(int index)
        {
            Me = index;
            return this;
        }
        
        
        public User Build()
        {
            User user = GD.Load<PackedScene>("res://scenes/player/user.tscn").Instantiate<User>();
            user.Hp = Hp;
            user.MaxHp = MaxHp;
            user.Energy = Energy;
            user.MaxEnergy = MaxEnergy;
            user.Position = pos;
            user.Weapon = w1;
            user.SecondWeapon = w2;
            user.inputManager = inputManager;
            user.AddChild(w1);
            user.AddChild(w2);
            user.SecondWeapon.Position = Vector2.One * 390625;
            user.Me = Me;
            return user;
        }
    }
    
}