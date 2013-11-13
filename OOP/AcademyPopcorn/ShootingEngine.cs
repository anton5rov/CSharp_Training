// Task 4. Inherit the engine class.

namespace AcademyPopcorn
{
    using System.Collections.Generic;

    public class ShootingEngine : Engine
    {
        private ShootingRacket playerRacket;
        
        public ShootingEngine(IRenderer renderer, IUserInterface userInterface, uint sleepTime)
            : base(renderer, userInterface, sleepTime)
        {   
        }

        // Have to override AddObject to instantiate the playerRacket.
        // Next call the base method AddObject.
        public override void AddObject(GameObject obj)
        {
            if (obj is ShootingRacket)
            {
                this.playerRacket = obj as ShootingRacket;
            }

            base.AddObject(obj);
        }

        public virtual void ShootPlayerRacket()
        {
            this.playerRacket.Shoot();
        }

        public int CheckBullets()
        {
            return this.playerRacket.GetBulletsCount();
        }
    }
}