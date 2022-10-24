namespace JsonBenchmarker.RootObjectDir;

public  class Rootobject {
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Username { get; set; }
  public string? Email { get; set; }
  public Address? Address { get; set; }
  public string? Phone { get; set; }
  public string? Website { get; set; }
  public Company? Company { get; set; }
  public Post[]? Posts { get; set; }
  public Comment1[]? Comments { get; set; }
  public Album[]? Albums { get; set; }
}

public  class Address {
  public string? street { get; set; }
  public string? suite { get; set; }
  public string? city { get; set; }
  public string? zipcode { get; set; }
  public Geo? geo { get; set; }
}

public  class Geo {
  public string? lat { get; set; }
  public string? lng { get; set; }
}

public  class Company {
  public string? name { get; set; }
  public string? catchPhrase { get; set; }
  public string? bs { get; set; }
}

public  class Post {
  public int Id { get; set; }
  public string? Title { get; set; }
  public string? Body { get; set; }
  public Comment[]? Comments { get; set; }
}

public  class Comment {
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Body { get; set; }
}

public  class Comment1 {
  public int Id { get; set; }
  public string? Name { get; set; }
  public string? Body { get; set; }
}

public  class Album {
  public int Id { get; set; }
  public string? Title { get; set; }
  public Photo[]? Photos { get; set; }
}

public  class Photo {
  public int Id { get; set; }
  public string? Title { get; set; }
  public string? Url { get; set; }
}