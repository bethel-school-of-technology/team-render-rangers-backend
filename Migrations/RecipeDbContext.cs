using feastly_api.Models;
using Microsoft.EntityFrameworkCore;

namespace feastly_api.Migrations;

public class RecipeDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }

    public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.Name).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Password).IsRequired();
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId);
            entity.Property(e => e.RecipeName).IsRequired();
            entity.Property(e => e.RecipeCategory).IsRequired();
            entity.Property(e => e.RecipeIngredients).IsRequired();
            entity.Property(e => e.RecipeInstructions).IsRequired();
            entity.Property(e => e.RecipeImgUrl).IsRequired();

            entity.HasOne(e => e.User)
                  .WithMany(u => u.Recipes)
                  .HasForeignKey(e => e.UserId);
        });

        modelBuilder.Entity<Recipe>().HasData(
     new Recipe
     {
         RecipeId = 1,
         RecipeName = "Blueberry Pancakes",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "1 cup Flour; 2 tbsp Sugar; 1 tsp Baking powder; 1 cup Milk; 1 Egg; 1 tbsp Butter; 1/2 cup Blueberries; Maple syrup",
         RecipeInstructions = "1. Mix flour, sugar, and baking powder. 2. Add milk, egg, and melted butter. 3. Stir in blueberries. 4. Cook on a greased skillet until bubbles form, flip and cook until golden. 5. Serve with maple syrup.",
         RecipeImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSx-DcxS4-vENpy8s70bg-b_JTQ6xPCrCn9ew&s",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 2,
         RecipeName = "French Toast",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "4 slices Bread; 2 Eggs; 1/2 cup Milk; 1 tsp Cinnamon; 2 tbsp Butter; Maple syrup",
         RecipeInstructions = "1. Whisk eggs, milk, and cinnamon in a bowl. 2. Dip bread slices in the mixture. 3. Cook on a greased skillet until golden brown. 4. Serve with maple syrup.",
         RecipeImgUrl = "https://live.staticflickr.com/5492/14033143291_fc4394c8ab_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 3,
         RecipeName = "Omelette with Spinach and Cheese",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "3 Eggs; 1/2 cup Spinach; 1/4 cup Shredded cheese; 1 tbsp Butter; Salt; Pepper",
         RecipeInstructions = "1. Whisk eggs with salt and pepper. 2. Cook spinach in a pan until wilted. 3. Pour eggs into the pan, add cheese and spinach. 4. Fold the omelette and cook until eggs are set.",
         RecipeImgUrl = "https://upload.wikimedia.org/wikipedia/commons/9/98/Omlette_with_cheese%2C_pine_nuts_and_spinach_%286058121433%29.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 4,
         RecipeName = "Breakfast Burrito",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "2 Tortillas; 2 Eggs; 1/4 cup Shredded cheese; 2 tbsp Salsa; 1/4 cup Black beans; 1/2 Avocado",
         RecipeInstructions = "1. Scramble eggs in a pan. 2. Warm tortillas. 3. Fill tortillas with eggs, cheese, beans, salsa, and avocado slices. 4. Fold and serve.",
         RecipeImgUrl = "https://live.staticflickr.com/2302/2221460943_3c5c1846a5_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 5,
         RecipeName = "Avocado Toast",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "2 slices Bread; 1 Avocado; 1 tbsp Olive oil; 1 tsp Lemon juice; Salt; Pepper",
         RecipeInstructions = "1. Mash avocado in a bowl with lemon juice, olive oil, salt, and pepper. 2. Toast bread slices. 3. Spread avocado mixture on toast. Serve immediately.",
         RecipeImgUrl = "https://freerangestock.com/sample/106345/avocado-toast-on-black-plate.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 6,
         RecipeName = "Eggs Benedict",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "4 Eggs; 4 slices Canadian bacon; 2 English muffins; 1/2 cup Butter; 2 tbsp Lemon juice; 2 tbsp White vinegar; Salt; Pepper",
         RecipeInstructions = "1. Poach eggs with vinegar in boiling water. 2. Toast English muffins and cook Canadian bacon. 3. Make hollandaise by whisking melted butter and lemon juice into egg yolks. 4. Assemble by placing bacon, poached eggs, and hollandaise on muffins. Serve.",
         RecipeImgUrl = "https://freerangestock.com/sample/164468/eggs-benedict-on-a-white-plate-with-asparagus.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 7,
         RecipeName = "Banana Oatmeal",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "1/2 cup Rolled oats; 1 Banana; 1 cup Milk; 1 tsp Cinnamon; 1 tbsp Honey; 1/4 tsp Vanilla extract",
         RecipeInstructions = "1. Cook oats with milk in a pot. 2. Mash banana and stir into oatmeal. 3. Add cinnamon, honey, and vanilla extract. Serve warm.",
         RecipeImgUrl = "https://live.staticflickr.com/4/4574592_069c9d7385_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 8,
         RecipeName = "Breakfast Quesadilla",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "2 Tortillas; 2 Eggs; 1/4 cup Shredded cheese; 2 tbsp Salsa; 1/4 cup Black beans; 1/2 Avocado",
         RecipeInstructions = "1. Scramble eggs in a pan. 2. Warm tortillas. 3. Fill tortillas with eggs, cheese, beans, salsa, and avocado slices. Fold and serve.",
         RecipeImgUrl = "https://live.staticflickr.com/7255/7075526013_e8502e5fa9_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 9,
         RecipeName = "Cinnamon Rolls",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "2 1/2 cups Flour; 1/2 cup Sugar; 2 1/4 tsp Yeast; 3/4 cup Milk; 1/4 cup Butter; 1 Egg; 1 tbsp Cinnamon; 1/2 cup Brown sugar",
         RecipeInstructions = "1. Mix flour, sugar, and yeast. 2. Heat milk and butter until warm, add to dry ingredients with egg. 3. Knead dough and let rise. 4. Roll out dough, spread with butter, cinnamon, and brown sugar. 5. Roll up and slice, bake at 350°F for 20-25 minutes.",
         RecipeImgUrl = "https://live.staticflickr.com/8514/8532489075_5df1b87c61_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 10,
         RecipeName = "Breakfast Smoothie",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "1 Banana; 1/2 cup Frozen berries; 1 cup Spinach; 1 tbsp Peanut butter; 1/2 cup Greek yogurt; 1/2 cup Milk",
         RecipeInstructions = "1. Blend banana, frozen berries, spinach, peanut butter, yogurt, and milk until smooth. Serve immediately.",
         RecipeImgUrl = "https://upload.wikimedia.org/wikipedia/commons/b/b7/Strawberry_Smoothie.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 11,
         RecipeName = "Hash Browns",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "2 large Potatoes; 1/4 cup Onion; 1 tbsp Butter; Salt; Pepper; 1/4 tsp Paprika",
         RecipeInstructions = "1. Grate potatoes and onion. 2. Heat butter in a skillet and cook potatoes with onion, paprika, salt, and pepper until crispy and golden. Serve warm.",
         RecipeImgUrl = "https://lacantinacatering.com/wp-content/uploads/2014/07/6235831243_ba46458d17_o.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 12,
         RecipeName = "Breakfast Frittata",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "6 Eggs; 1/2 cup Spinach; 1/4 cup Shredded cheese; 1/4 cup Bell pepper; 1 tbsp Olive oil; Salt; Pepper",
         RecipeInstructions = "1. Preheat oven to 375°F. 2. Whisk eggs with salt and pepper. 3. Sauté spinach and bell pepper in olive oil. 4. Pour eggs into pan and top with cheese. 5. Bake for 15-20 minutes until set.",
         RecipeImgUrl = "https://i1.pickpik.com/photos/312/748/909/5970518bcbd5e-preview.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 13,
         RecipeName = "Mushroom and Cheese Scramble",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "3 Eggs; 1/2 cup Mushrooms; 1/4 cup Shredded cheese; 1 tbsp Butter; Salt; Pepper",
         RecipeInstructions = "1. Sauté mushrooms in butter. 2. Scramble eggs with salt and pepper. 3. Stir in mushrooms and cheese, cook until set. Serve warm.",
         RecipeImgUrl = "https://live.staticflickr.com/6148/6024520369_04c9e5681d_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 14,
         RecipeName = "Breakfast Parfait",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "1/2 cup Greek yogurt; 1/4 cup Granola; 1/4 cup Mixed berries; 1 tbsp Honey",
         RecipeInstructions = "1. Layer yogurt, granola, and berries in a bowl or jar. 2. Drizzle with honey. Serve immediately.",
         RecipeImgUrl = "https://live.staticflickr.com/7120/7432697864_e96f7a3604_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 15,
         RecipeName = "Bagel with Cream Cheese and Smoked Salmon",
         RecipeCategory = "Breakfast",
         RecipeIngredients = "2 Bagels; 4 oz Cream cheese; 4 oz Smoked salmon; 1 tbsp Capers; 1/2 Red onion; 1 tbsp Lemon juice",
         RecipeInstructions = "1. Toast bagels. 2. Spread cream cheese on each half. 3. Top with smoked salmon, capers, red onion, and lemon juice. Serve.",
         RecipeImgUrl = "https://img.cc1.de/1095000/preview/1098738_50a4c7b48b70e2206a7c4481ef748d33.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 16,
         RecipeName = "Chicken Caesar Wrap",
         RecipeCategory = "Lunch",
         RecipeIngredients = "1 Chicken breast; 1 cup Romaine lettuce; 2 tbsp Caesar dressing; 1/4 cup Parmesan cheese; 1 Tortilla wrap; 1/4 cup Croutons",
         RecipeInstructions = "1. Grill the chicken and slice. 2. Toss Romaine lettuce with Caesar dressing and croutons. 3. Place chicken and lettuce mixture in a tortilla, top with Parmesan, and wrap.",
         RecipeImgUrl = "https://bakesbybrownsugar.com/wp-content/uploads/2021/06/Avocado-Chicken-Salad-Wrap-13-480x270.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 17,
         RecipeName = "Chicken Noodle Soup",
         RecipeCategory = "Lunch",
         RecipeIngredients = "1 lb Chicken breast; 2 Carrots; 2 stalks Celery; 1 Onion; 8 oz Egg noodles; 6 cups Chicken broth; 3 Garlic cloves; 1 tsp Thyme; 1 Bay leaf; Salt; Pepper",
         RecipeInstructions = "1. Cook chicken with broth, carrots, celery, onion, garlic, and thyme. 2. Add egg noodles and simmer until tender. 3. Season with bay leaf, salt, and pepper. Serve warm.",
         RecipeImgUrl = "https://live.staticflickr.com/4035/4354055308_4625f9ef20_z.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 18,
         RecipeName = "Turkey Club Sandwich",
         RecipeCategory = "Lunch",
         RecipeIngredients = "4 slices Turkey breast; 4 slices Bacon; 1/2 cup Lettuce; 1 Tomato; 2 tbsp Mayo; 3 slices Bread",
         RecipeInstructions = "1. Toast the bread slices. 2. Cook bacon until crispy. 3. Layer turkey, bacon, lettuce, tomato, and mayo between bread slices. Cut and serve.",
         RecipeImgUrl = "https://live.staticflickr.com/7333/8939668729_925dcc6c28_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 19,
         RecipeName = "Caprese Sandwich",
         RecipeCategory = "Lunch",
         RecipeIngredients = "4 slices Mozzarella cheese; 1 Tomato; 6 Fresh basil leaves; 1 tbsp Balsamic glaze; 1 tbsp Olive oil; 2 slices Ciabatta bread",
         RecipeInstructions = "1. Toast ciabatta bread. 2. Layer mozzarella, tomato, and basil leaves on the bread. 3. Drizzle with balsamic glaze and olive oil. Serve warm or cold.",
         RecipeImgUrl = "https://live.staticflickr.com/2559/3733274956_aefe550d4c_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 20,
         RecipeName = "Tomato Basil Soup",
         RecipeCategory = "Lunch",
         RecipeIngredients = "6 Tomatoes; 1 Onion; 3 Garlic cloves; 1/4 cup Fresh basil; 2 tbsp Olive oil; 4 cups Vegetable broth; Salt; Pepper; 1/2 cup Heavy cream",
         RecipeInstructions = "1. Sauté onions and garlic in olive oil. 2. Add tomatoes and vegetable broth, simmer for 20 minutes. 3. Blend until smooth, stir in basil and heavy cream. 4. Season with salt and pepper, serve warm.",
         RecipeImgUrl = "https://i1.pickpik.com/photos/435/66/530/food-drink-food-healthy-soup-preview.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 21,
         RecipeName = "Tuna Salad",
         RecipeCategory = "Lunch",
         RecipeIngredients = "1 can Tuna; 2 tbsp Mayo; 1/4 cup Celery; 1/4 cup Red onion; 1 tbsp Lemon juice; Salt; Pepper; 1 cup Lettuce",
         RecipeInstructions = "1. Mix tuna, mayo, celery, red onion, and lemon juice. 2. Season with salt and pepper. 3. Serve on a bed of lettuce or in a sandwich.",
         RecipeImgUrl = "https://live.staticflickr.com/6037/5885948734_20b828a2ce_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 22,
         RecipeName = "Chicken Quesadilla",
         RecipeCategory = "Lunch",
         RecipeIngredients = "1 Chicken breast; 1/2 cup Shredded cheese; 2 Tortillas; 1/4 cup Bell peppers; 1/4 cup Onion; 2 tbsp Salsa; 2 tbsp Sour cream",
         RecipeInstructions = "1. Cook chicken, bell peppers, and onions in a skillet. 2. Place mixture between tortillas with shredded cheese. 3. Cook until crispy, and serve with salsa and sour cream.",
         RecipeImgUrl = "https://live.staticflickr.com/4154/4957050596_fd856412e6_z.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 23,
         RecipeName = "Butternut Squash Soup",
         RecipeCategory = "Lunch",
         RecipeIngredients = "1 Butternut squash; 1 Onion; 3 Garlic cloves; 1 tbsp Fresh ginger; 1 can Coconut milk; 4 cups Vegetable broth; 2 tbsp Olive oil; Salt; Pepper",
         RecipeInstructions = "1. Roast butternut squash in olive oil until tender. 2. Sauté onion, garlic, and ginger. 3. Blend squash with coconut milk and vegetable broth. 4. Season with salt and pepper, serve warm.",
         RecipeImgUrl = "https://live.staticflickr.com/5245/5312936845_c6866f7e8a_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 24,
         RecipeName = "Mediterranean Hummus Wrap",
         RecipeCategory = "Lunch",
         RecipeIngredients = "1/4 cup Hummus; 1/4 cup Cucumber; 1/4 cup Red onion; 1/4 cup Bell peppers; 1/4 cup Feta cheese; 1 Whole wheat wrap; 1/4 cup Olives",
         RecipeInstructions = "1. Spread hummus on the wrap. 2. Add cucumber, red onion, bell peppers, olives, and feta cheese. 3. Wrap tightly and serve.",
         RecipeImgUrl = "https://live.staticflickr.com/1410/1080528765_c427158666_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 25,
         RecipeName = "BBQ Pulled Pork Sandwich",
         RecipeCategory = "Lunch",
         RecipeIngredients = "1/2 lb Pulled pork; 1/4 cup BBQ sauce; 1/2 cup Coleslaw; 2 Brioche buns",
         RecipeInstructions = "1. Toss pulled pork with BBQ sauce. 2. Place pork on brioche buns, top with coleslaw, and serve.",
         RecipeImgUrl = "https://live.staticflickr.com/2787/4207641044_072520a3c6_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 26,
         RecipeName = "Egg Salad Sandwich",
         RecipeCategory = "Lunch",
         RecipeIngredients = "4 Boiled eggs; 2 tbsp Mayo; 1 tsp Mustard; 1/4 cup Celery; Salt; Pepper; 2 slices Bread",
         RecipeInstructions = "1. Mash boiled eggs with mayo, mustard, and celery. 2. Season with salt and pepper. 3. Spread onto bread slices, serve.",
         RecipeImgUrl = "https://live.staticflickr.com/8453/8039148699_382a40b4a8_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 27,
         RecipeName = "Minestrone Soup",
         RecipeCategory = "Lunch",
         RecipeIngredients = "1 Zucchini; 2 Carrots; 2 stalks Celery; 4 Tomatoes; 1 can White beans; 1 cup Pasta; 4 cups Vegetable broth; 2 Garlic cloves; 1 Onion; 1 tsp Italian seasoning; Salt; Pepper",
         RecipeInstructions = "1. Sauté onions and garlic in olive oil. 2. Add carrots, celery, zucchini, and tomatoes. 3. Pour in vegetable broth and add beans and pasta. 4. Simmer until pasta is cooked. 5. Season with Italian seasoning, salt, and pepper, serve.",
         RecipeImgUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3e/Minestrone_al_profumo_di_basilico.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 28,
         RecipeName = "Lemon Garlic Shrimp",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 lb Shrimp; 2 Garlic cloves; 2 tbsp Lemon juice; 2 tbsp Olive oil; 1 tsp Paprika; Salt; Pepper",
         RecipeInstructions = "1. Marinate shrimp with garlic, lemon juice, olive oil, paprika, salt, and pepper. 2. Heat a skillet and cook shrimp for 2-3 minutes per side until pink. Serve.",
         RecipeImgUrl = "https://images.pexels.com/photos/8633745/pexels-photo-8633745.jpeg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 29,
         RecipeName = "Chicken Fajitas",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 lb Chicken breast; 1 Red bell pepper; 1 Green bell pepper; 1 Onion; 2 tbsp Fajita seasoning; 8 Tortillas",
         RecipeInstructions = "1. Slice chicken, bell peppers, and onion. 2. Cook chicken and vegetables in a skillet with fajita seasoning. 3. Serve with warm tortillas.",
         RecipeImgUrl = "https://live.staticflickr.com/3626/3496175070_a8f44db07e_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 30,
         RecipeName = "Vegetable Curry",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 Onion; 2 Garlic cloves; 2 cups Mixed vegetables; 1 can Coconut milk; 2 tbsp Curry powder; 1 tbsp Olive oil; Salt; Pepper",
         RecipeInstructions = "1. Heat oil in a pot and sauté onion and garlic. 2. Add vegetables and curry powder. 3. Pour in coconut milk, season with salt and pepper. 4. Simmer for 20 minutes and serve.",
         RecipeImgUrl = "https://media.freemalaysiatoday.com/wp-content/uploads/2024/09/70f2863a-aviyal-orange-sieve-pic-190824.webp",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 31,
         RecipeName = "Grilled Steak Salad",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 lb Steak; 4 cups Mixed greens; 1/4 cup Feta cheese; 1/4 cup Olive oil; 2 tbsp Balsamic vinegar; Salt; Pepper",
         RecipeInstructions = "1. Grill steak to desired doneness. 2. Slice steak and toss with mixed greens, feta, olive oil, balsamic vinegar, salt, and pepper.",
         RecipeImgUrl = "https://live.staticflickr.com/5442/9174866261_4c1908cf9b_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 32,
         RecipeName = "Spaghetti Carbonara",
         RecipeCategory = "Dinner",
         RecipeIngredients = "7 oz Spaghetti; 3.5 oz Pancetta; 1/2 cup Parmesan cheese; 2 large Eggs; 2 cloves Garlic; Black pepper; Salt",
         RecipeInstructions = "1. Cook spaghetti according to package instructions. 2. Fry pancetta with garlic until crisp. 3. Beat eggs and mix with Parmesan. 4. Combine spaghetti with pancetta and egg mixture. 5. Season with black pepper and salt, serve.",
         RecipeImgUrl = "https://upload.wikimedia.org/wikipedia/commons/3/30/Spaghetti_carbonara.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 33,
         RecipeName = "Chicken Tikka Masala",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 lb Chicken breast; 1 cup Yogurt; 1 tbsp Garam masala; 1 tsp Turmeric; 1 tsp Cumin; 1 Onion; 2 Garlic cloves; 14 oz Tomatoes; 1 cup Cream",
         RecipeInstructions = "1. Marinate chicken in yogurt, garam masala, turmeric, and cumin. 2. Cook onion and garlic until soft. 3. Add marinated chicken, tomatoes, and cream. 4. Simmer for 20 minutes until chicken is cooked through. Serve with rice.",
         RecipeImgUrl = "https://live.staticflickr.com/4110/5040128576_b1f5ea599b_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 34,
         RecipeName = "Vegetable Stir-fry",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 Broccoli head; 1 Carrot; 1 Bell pepper; 3.5 oz Snow peas; 2 tbsp Soy sauce; 1 tbsp Sesame oil; 1 tsp Ginger; 2 Garlic cloves",
         RecipeInstructions = "1. Heat sesame oil in a wok. 2. Stir-fry garlic and ginger for 1 minute. 3. Add broccoli, carrot, bell pepper, and snow peas. 4. Stir-fry for 5-7 minutes. 5. Add soy sauce and serve.",
         RecipeImgUrl = "https://live.staticflickr.com/2521/4375286329_c5937ee997_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 35,
         RecipeName = "Beef Tacos",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 lb Ground beef; 1 packet Taco seasoning; 8 small Tortillas; 1 Onion; 1 Tomato; 1 cup Lettuce; 1/2 cup Cheddar cheese; 1/2 cup Sour cream",
         RecipeInstructions = "1. Cook ground beef with taco seasoning. 2. Warm tortillas. 3. Assemble tacos with beef, lettuce, tomato, onion, cheese, and sour cream. Serve immediately.",
         RecipeImgUrl = "https://img.cc1.de/1100000/preview/1100417_434d11c292b7a3b83c365e58331aa204.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 36,
         RecipeName = "Grilled Lemon Salmon",
         RecipeCategory = "Dinner",
         RecipeIngredients = "4 Salmon fillets; 2 tbsp Olive oil; 1 Lemon; 2 Garlic cloves; 1 tsp Dill; Salt; Pepper",
         RecipeInstructions = "1. Preheat grill. 2. Mix olive oil, lemon juice, garlic, dill, salt, and pepper. 3. Brush salmon with marinade. 4. Grill for 5-7 minutes per side. Serve with roasted zucchini.",
         RecipeImgUrl = "https://freerangestock.com/sample/180329/salmon-fillet-with-seasoned-zucchini-in-a-baking-dish.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 37,
         RecipeName = "Quinoa Salad",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 cup Quinoa; 1 Cucumber; 1 cup Cherry tomatoes; 1 Red onion; 3.5 oz Feta cheese; 2 tbsp Olive oil; 1 tbsp Lemon juice; Salt; Pepper",
         RecipeInstructions = "1. Cook quinoa according to package instructions. 2. Chop cucumber, tomatoes, and onion. 3. Mix quinoa with vegetables and feta. 4. Drizzle with olive oil and lemon juice. Season with salt and pepper, serve.",
         RecipeImgUrl = "https://live.staticflickr.com/3864/18859209905_7779fb7ec1_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 38,
         RecipeName = "BBQ Chicken Pizza",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 Pizza dough; 1 Chicken breast; 1/2 cup BBQ sauce; 1 cup Mozzarella cheese; 1 Red onion; 2 tbsp Cilantro",
         RecipeInstructions = "1. Preheat oven to 220°C. 2. Cook chicken and shred. 3. Roll out pizza dough and spread BBQ sauce. 4. Top with chicken, mozzarella, and onion. 5. Bake for 12-15 minutes. 6. Garnish with cilantro and serve.",
         RecipeImgUrl = "https://img.cc1.de/1095000/preview/1098349_e035a91895c17e351157c805b816ba0f.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 39,
         RecipeName = "Greek Salad",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 Cucumber; 4 Tomatoes; 1 Red onion; 1/2 cup Olives; 3.5 oz Feta cheese; 2 tbsp Olive oil; 1 tbsp Lemon juice; Oregano",
         RecipeInstructions = "1. Chop cucumber, tomatoes, and onion. 2. Toss with olives and feta. 3. Drizzle with olive oil and lemon juice. Sprinkle oregano, serve.",
         RecipeImgUrl = "https://images.pexels.com/photos/8697517/pexels-photo-8697517.jpeg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 40,
         RecipeName = "Stuffed Bell Peppers",
         RecipeCategory = "Dinner",
         RecipeIngredients = "4 Bell peppers; 1 lb Ground beef; 1 cup Cooked rice; 1 cup Marinara sauce; 1 cup Mozzarella cheese; 1 Onion; Salt; Pepper",
         RecipeInstructions = "1. Preheat oven to 375°F. 2. Cut tops off bell peppers and remove seeds. 3. Cook ground beef with onion, rice, and marinara sauce. 4. Stuff peppers with the mixture and top with cheese. 5. Bake for 30 minutes.",
         RecipeImgUrl = "https://upload.wikimedia.org/wikipedia/commons/f/fa/Stuffed_Peppers_04of9_%288735185033%29.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 41,
         RecipeName = "Baked Ziti",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 lb Ziti pasta; 1 jar Marinara sauce; 1 lb Ground beef; 1 Onion; 2 cups Mozzarella cheese; 1 cup Ricotta cheese; Salt; Pepper",
         RecipeInstructions = "1. Preheat oven to 350°F. 2. Cook ziti according to package. 3. Brown ground beef with onion. 4. Mix pasta with marinara, beef, and ricotta. 5. Transfer to a baking dish, top with mozzarella, bake for 25 minutes.",
         RecipeImgUrl = "https://live.staticflickr.com/2541/3680411216_1967bf1fd8_z.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 42,
         RecipeName = "Teriyaki Chicken",
         RecipeCategory = "Dinner",
         RecipeIngredients = "4 Chicken thighs; 1/4 cup Soy sauce; 2 tbsp Honey; 2 Garlic cloves; 1 tbsp Sesame oil; 1 tbsp Sesame seeds; Salt; Pepper",
         RecipeInstructions = "1. Marinate chicken in soy sauce, honey, garlic, and sesame oil. 2. Cook in a skillet over medium heat for 6-8 minutes on each side. 3. Garnish with sesame seeds and serve.",
         RecipeImgUrl = "https://i2.pickpik.com/photos/573/364/951/sushi-japan-japan-cuisine-gourmet-preview.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 43,
         RecipeName = "Shrimp Scampi",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 lb Shrimp; 4 Garlic cloves; 4 tbsp Butter; 1/4 cup White wine; 1 Lemon; 1/2 cup Parsley; 1 lb Spaghetti; Salt; Pepper",
         RecipeInstructions = "1. Cook spaghetti according to package instructions. 2. Sauté garlic in butter, add shrimp and cook until pink. 3. Deglaze with white wine and lemon juice. 4. Toss shrimp with pasta, garnish with parsley.",
         RecipeImgUrl = "https://live.staticflickr.com/66/161224077_17bc6c759f_c.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 44,
         RecipeName = "Beef Stroganoff",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 lb Beef sirloin; 1 Onion; 1 cup Sour cream; 1/2 cup Beef broth; 2 tbsp Flour; 1 tbsp Butter; Salt; Pepper",
         RecipeInstructions = "1. Brown beef in butter, set aside. 2. Sauté onions, add flour, broth, and sour cream. 3. Return beef to the pan and simmer until thickened. Serve over egg noodles.",
         RecipeImgUrl = "https://live.staticflickr.com/4034/4691517804_9b3bb384d0_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 45,
         RecipeName = "Chicken Alfredo",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 lb Fettuccine; 2 Chicken breasts; 1 cup Heavy cream; 1/2 cup Parmesan cheese; 2 tbsp Butter; 2 Garlic cloves; Salt; Pepper",
         RecipeInstructions = "1. Cook fettuccine according to package. 2. Sauté garlic in butter, add chicken and cook through. 3. Add cream and Parmesan, simmer until thickened. Toss with pasta.",
         RecipeImgUrl = "https://img.cc1.de/1095000/preview/1099295_db8da4d58b684a7baf646b983fff9337.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 46,
         RecipeName = "Mushroom Risotto",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 cup Arborio rice; 1/2 cup White wine; 4 cups Chicken broth; 1 Onion; 1 cup Mushrooms; 1/4 cup Parmesan cheese; 2 tbsp Butter",
         RecipeInstructions = "1. Sauté onions and mushrooms in butter. 2. Add rice, toast for 1 minute. 3. Deglaze with white wine, then add broth slowly, stirring constantly. 4. Stir in Parmesan and serve.",
         RecipeImgUrl = "https://img.cc1.de/1095000/preview/1099302_a8506a578ab82d25b5a3916a52b85a64.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 47,
         RecipeName = "Pork Tenderloin with Apples",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 Pork tenderloin; 2 Apples; 1 Onion; 1 tbsp Olive oil; 1/4 cup Apple cider vinegar; 1 tsp Thyme; Salt; Pepper",
         RecipeInstructions = "1. Preheat oven to 400°F. 2. Sear pork in a skillet with olive oil. 3. Add sliced apples, onions, vinegar, and thyme. 4. Roast in the oven for 20 minutes until cooked through.",
         RecipeImgUrl = "https://live.staticflickr.com/4468/37213014350_14b979ca08_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 48,
         RecipeName = "Fish Tacos",
         RecipeCategory = "Dinner",
         RecipeIngredients = "1 lb White fish fillets; 8 Tortillas; 1 cup Cabbage; 1/4 cup Cilantro; 1/2 cup Sour cream; 1 tbsp Chili powder; 1 Lime",
         RecipeInstructions = "1. Season fish with chili powder and grill. 2. Warm tortillas and assemble with fish, cabbage, cilantro, and sour cream. Squeeze lime juice on top and serve.",
         RecipeImgUrl = "https://live.staticflickr.com/7432/9641664708_9ee3c3233d_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 49,
         RecipeName = "Eggplant Parmesan",
         RecipeCategory = "Dinner",
         RecipeIngredients = "2 Eggplants; 1 cup Bread crumbs; 1 jar Marinara sauce; 2 cups Mozzarella cheese; 1/2 cup Parmesan cheese; 1/4 cup Olive oil; Salt; Pepper",
         RecipeInstructions = "1. Slice and salt eggplants, let sit for 20 minutes. 2. Coat in breadcrumbs and fry in olive oil. 3. Layer eggplant, marinara, and cheeses in a baking dish. 4. Bake at 375°F for 30 minutes.",
         RecipeImgUrl = "https://live.staticflickr.com/2555/3795077743_fa876d8536_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 50,
         RecipeName = "Chocolate Brownies",
         RecipeCategory = "Dessert",
         RecipeIngredients = "1 cup Flour; 1/2 cup Butter; 1 cup Sugar; 2 Eggs; 1/2 cup Cocoa powder; 1/4 tsp Salt; 1/2 tsp Vanilla extract",
         RecipeInstructions = "1. Preheat oven to 180°C. 2. Melt butter and mix with sugar. 3. Stir in eggs and vanilla. 4. Mix in flour, cocoa, and salt. 5. Pour batter into a pan and bake for 25-30 minutes.",
         RecipeImgUrl = "https://i2.pickpik.com/photos/958/928/965/fudge-brownies-snack-chocolate-delicious-preview.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 51,
         RecipeName = "Lemon Bars",
         RecipeCategory = "Dessert",
         RecipeIngredients = "1 cup Butter; 2 cups Flour; 1/2 cup Sugar; 1/4 cup Lemon juice; 1 tbsp Lemon zest; 1 1/2 cups Powdered sugar; 4 Eggs",
         RecipeInstructions = "1. Preheat oven to 350°F. 2. Mix butter, flour, and sugar, press into a baking dish. 3. Bake for 15 minutes. 4. Whisk eggs, lemon juice, zest, and powdered sugar. 5. Pour over crust and bake for 20 minutes.",
         RecipeImgUrl = "https://live.staticflickr.com/65535/51318117793_ba1d20467a_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 52,
         RecipeName = "Apple Pie",
         RecipeCategory = "Dessert",
         RecipeIngredients = "6 Apples; 1/2 cup Sugar; 1/2 cup Brown sugar; 1 tsp Cinnamon; 1/4 tsp Nutmeg; 2 Pie crusts; 2 tbsp Butter; 1 tbsp Lemon juice",
         RecipeInstructions = "1. Preheat oven to 375°F. 2. Peel and slice apples, mix with sugar, cinnamon, nutmeg, and lemon juice. 3. Line pie dish with crust, fill with apples, dot with butter. 4. Cover with second crust, bake for 45-50 minutes.",
         RecipeImgUrl = "https://images.pexels.com/photos/9502639/pexels-photo-9502639.jpeg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 53,
         RecipeName = "Chocolate Chip Muffins",
         RecipeCategory = "Dessert",
         RecipeIngredients = "1 1/2 cups Flour; 1/2 cup Butter; 1 cup Sugar; 2 Eggs; 1 tsp Vanilla extract; 1/2 cup Chocolate chips; 1/4 tsp Salt; 1/2 tsp Baking powder",
         RecipeInstructions = "1. Preheat oven to 350°F. 2. Cream butter and sugar. 3. Add eggs and vanilla extract. 4. Stir in flour, baking powder, salt, and chocolate chips. 5. Scoop batter into muffin tin and bake for 18-20 minutes.",
         RecipeImgUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c3/Banana_nut_muffins_with_raisins_and_chocolate_%286150882978%29.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 54,
         RecipeName = "Vanilla Cupcakes",
         RecipeCategory = "Dessert",
         RecipeIngredients = "1 1/2 cups Flour; 1/2 cup Butter; 1 cup Sugar; 2 Eggs; 1/2 cup Milk; 1 tsp Vanilla extract; 1 1/2 tsp Baking powder; 1/4 tsp Salt",
         RecipeInstructions = "1. Preheat oven to 350°F. 2. Cream butter and sugar. 3. Add eggs and vanilla extract. 4. Stir in flour, baking powder, and salt. 5. Spoon batter into cupcake liners, bake for 20-25 minutes.",
         RecipeImgUrl = "https://live.staticflickr.com/3288/2838214387_799c239cb0_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 55,
         RecipeName = "Tiramisu",
         RecipeCategory = "Dessert",
         RecipeIngredients = "6 Egg yolks; 3/4 cup Sugar; 2 cups Mascarpone cheese; 1 1/2 cups Heavy cream; 2 cups Espresso; 24 Ladyfingers; 2 tbsp Cocoa powder",
         RecipeInstructions = "1. Whisk egg yolks and sugar over simmering water until thickened. 2. Beat in mascarpone cheese. 3. Whip heavy cream until stiff peaks form. 4. Dip ladyfingers in espresso. 5. Layer cream and ladyfingers in a dish, dust with cocoa powder. Refrigerate.",
         RecipeImgUrl = "https://pd.w.org/2022/09/514632a8d03222554.67030706.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 56,
         RecipeName = "Peach Cobbler",
         RecipeCategory = "Dessert",
         RecipeIngredients = "4 Peaches; 1 cup Flour; 1 cup Sugar; 1/2 cup Brown sugar; 1/2 cup Butter; 1 tsp Cinnamon; 1 tsp Baking powder; 1/4 tsp Salt",
         RecipeInstructions = "1. Preheat oven to 350°F. 2. Slice peaches and mix with sugar and cinnamon. 3. In another bowl, mix flour, baking powder, and salt. 4. Add melted butter and sugar, stir until combined. 5. Layer peaches and batter in a baking dish, bake for 40 minutes.",
         RecipeImgUrl = "https://live.staticflickr.com/6088/6055884449_31e2fa1ba1_b.jpg",
         UserId = 1
     },
     new Recipe
     {
         RecipeId = 57,
         RecipeName = "Cheesecake",
         RecipeCategory = "Dessert",
         RecipeIngredients = "2 cups Cream cheese; 1 cup Sugar; 3 Eggs; 1/2 cup Sour cream; 1 tsp Vanilla extract; 1/4 cup Butter; 1 cup Graham cracker crumbs",
         RecipeInstructions = "1. Preheat oven to 325°F. 2. Mix cream cheese, sugar, and vanilla extract. 3. Add eggs one at a time, mix until smooth. 4. Stir in sour cream. 5. Press graham cracker crumbs and butter into a crust. 6. Pour filling into crust, bake for 50 minutes.",
         RecipeImgUrl = "https://freerangestock.com/sample/150526/a-cheesecake-with-a-slice-missing.jpg",
         UserId = 1
     }
 );
    }
}