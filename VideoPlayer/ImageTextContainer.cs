using System;
using System.Drawing;
using System.Windows.Forms;

public class ImageTextContainer : UserControl
{
    private PictureBox pictureBox;
    private Label label;

    public event EventHandler ContainerClicked;

    public ImageTextContainer(string image, string title)
    {
        InitializeComponents(image,title);
        
        
    }
    private void InitializeComponents(string image, string title)
    {
        // Configurar PictureBox
        pictureBox = new PictureBox
        {
            Image = Image.FromFile(image),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Size = new Size(50, 50), // Tamaño de la imagen
            Location = new Point(5, 5)
        };

        // Configurar Label
        label = new Label
        {
            Text = title,
            AutoSize = true,
            Location = new Point(60, 20), // Posición del texto
            Font = new Font("Arial", 10)
        };

        // Configurar el contenedor principal
        this.Controls.Add(pictureBox);
        this.Controls.Add(label);
        this.Size = new Size(200, 60); // Tamaño del contenedor
        this.BorderStyle = BorderStyle.FixedSingle;

        // Añadir evento de clic al contenedor
        this.Click += (s, e) => ContainerClicked?.Invoke(this, e);

        // Propagar el clic de los controles hijos
        pictureBox.Click += (s, e) => ContainerClicked?.Invoke(this, e);
        label.Click += (s, e) => ContainerClicked?.Invoke(this, e);
    }

    // Propiedad para establecer la imagen
    public Image ContainerImage
    {
        get => pictureBox.Image;
        set => pictureBox.Image = value;
    }

    // Propiedad para establecer el texto
    public string ContainerText
    {
        get => label.Text;
        set => label.Text = value;
    }


}
